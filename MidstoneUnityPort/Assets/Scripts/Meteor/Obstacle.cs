﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    public GameObject effect;
    private obstacle_anim obsMove;

    private void Start()
    {

        //obsMove = GameObject.FindGameObjectWithTag("ObstacleSprite").GetComponent<obstacle_anim>();

        GameObject[] obj = GameObject.FindGameObjectsWithTag("ObstacleSprite");

        if (obj.Length > 0)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                obstacle_anim obsMove = obj[i].GetComponent<obstacle_anim>();
                if (obsMove)
                {
                    obsMove.ObstacleMoving();
                }
            }
        }
    }

    private void Update()
    {
        //Obstacle moving continually left
        //obsMove.ObstacleMoving();
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Player taking damage upon collision with obstacle
        if (other.CompareTag("Player"))
        {
            //spawn obstacle destroy particle effect
            Instantiate(effect, transform.position, Quaternion.identity);
            //lower player health, set damage # in inspector
            other.GetComponent<Player>().health -= damage;
            Debug.Log(other.GetComponent<Player>().health);
            Destroy(gameObject);
        }

        if (other.CompareTag("Laser"))
        {
            Destroy(gameObject);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
