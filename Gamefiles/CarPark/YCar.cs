﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YCar : MonoBehaviour
{
    public int CarNumber;
    private CarGameManager cGM;

    private Button up;
    private Button right;
    private Button down;
    private Button left;
    private Text textArea;

    private bool meMove;
    private Vector3 lastLocation;

    // Use this for initialization
    void Start()
    {
        cGM = GameObject.Find("CarGameManager").GetComponent<CarGameManager> ();
    }

    /// jokaisella autolla on CarNumber int
    /// kutsutaan CarGameManager luokan SelectCarY metodia
    /// </summary>
    void OnMouseDown()
    {
        cGM.SelectCarY(CarNumber);

    }

    /// liikutetaan autoa y suunnassa
    /// bool meMove halutaan, että vain liikkunut auto palautetaan takaisin vanhaan positioniin
    public void MoveCar(string direction)
    {
        meMove = true;
        lastLocation = transform.position;
        if (direction.Equals("up"))
        {
            transform.Translate(0f, 61f, 0f);
        }
        if (direction.Equals("down"))
        {
            transform.Translate(0f, -61f, 0f);
        }
        StartCoroutine(WaitTime());
    }

    /// <summary>
    /// Törmäyksessä liikkuva auto palautetaan vahnaan poisioniin
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter2D(Collision2D col)
    {
        if (meMove == true)
        { 
            transform.position = lastLocation;
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.05f);
        meMove = false;
    }
}
