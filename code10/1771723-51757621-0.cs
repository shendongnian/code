    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class Player : MonoBehaviour {
	public string name;
	public int power;
	public int speed;
	public void gameData() {
		print ("Player name = " + name);
		print ("Player power = " + power);
		print ("Player speed = " + speed);   
	}
	void Attack () {
		 
	}
    }
..
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class UsingStuff : MonoBehaviour {
	Player P1 = new Player();
	Player P2 = new Player();
	Player P3 = new Player();
	// Use this for initialization
	void Start () {
		P1.name = "Bill";
		P1.power = 10;
		P1.speed = 30;
		P2.name = "Bob";
		P2.power = 100;
		P2.speed = 3;
		P3.name = "Jerry";
		P3.power = 50;
		P3.speed = 10;
		P1.gameData ();
		P2.gameData ();
		P3.gameData ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    }
