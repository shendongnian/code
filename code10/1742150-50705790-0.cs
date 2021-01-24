    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using System.Threading;
    
    public class Ball : MonoBehaviour {
    	public float RotateSpeed = 45; //The ball rotates around its own axis
    	public float BallSpeed = 0.2f; 
    
    	public GameObject BaseBall;
    	public Transform BallLocation;
    
    	public Rigidbody2D Ball2D;
    
    	void Start() {
    		Ball2D = GetComponent<Rigidbody2D>(); //Get component attached to gameobject
    		InvokeRepeating("Spawn", 5.0f, 150f);
    	}		
    
    	void FixedUpdate() {
    		Ball2D.MoveRotation(Ball2D.rotation + RotateSpeed * Time.fixedDeltaTime); //The ball rotates around its own axis
    		Ball2D.AddForce(Vector2.left * BallSpeed);
    	}
    
    	public void Spawn () 
    	{
    		Instantiate (BaseBall, BallLocation.position, BallLocation.rotation);
    	}
    }
	
