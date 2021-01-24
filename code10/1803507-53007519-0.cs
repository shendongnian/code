    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class UpdateScoreWhileMousePressed : MonoBehaviour {
    
        public Vector3 mouseDelta = Vector3.zero;
        private Vector3 lastPos = Vector3.zero;
    
        public float mouseSpeed;
    
        public Text scoretext;
        public int score;
    
        public float timeToGo;
    
        // Use this for initialization
        void Start () {
    
            timeToGo = Time.fixedTime;
            mouseDelta = Input.mousePosition;
            lastPos = Input.mousePosition;
    
    	}
    	
    	// Update is called once per frame
    	void Update () {
    
            
    
        }
    
        // Update is called every 0.2 seconds
        private void FixedUpdate()
        {
            if(Time.fixedTime > timeToGo)
            {
                
                //Update mouseDelta
                mouseDelta = Input.mousePosition - lastPos;
    
                //Calculate mouseSpeed
                mouseSpeed = mouseDelta.magnitude / Time.deltaTime;
    
                scoretext.text = "Score: " + score;
    
                Debug.Log("Speed: " + mouseSpeed);
                Debug.Log("Score: " + score);
    
                //If the mouse is being pressed the score will increase by 1 every call
                if (Input.GetMouseButton(0))
                {
    
                    if(mouseSpeed <= 1000)
                    {
                        score += 1;
                    }
    
                    //And receive multipliers for faster speed
                    else if(mouseSpeed > 1000 & mouseSpeed < 2000)
                    {
                        score += 1 * 2;
                    }
    
                    else if(mouseSpeed >= 2000 & mouseSpeed < 4000)
                    {
                        score += 1 * 3;
                    }
    
                    else if(mouseSpeed >=4000 & mouseSpeed < 8000)
                    {
                        score += 1 * 4;
                    }
    
                    else if(mouseSpeed >= 8000)
                    {
                        score += 1 * 5;
                    }
    
                }
    
                //Update lastPost
                lastPos = Input.mousePosition;
    
                //Update timeToGo
                timeToGo = Time.fixedTime + 0.2f;
            }
    
    
        }
    
    }
