    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class ProximityTeleport : MonoBehaviour {
        public float time;
        public int timer1 = 0;
        public int teleport = 0;
        public float timecountdown;   
    
        void Start () {
            timecountdown = 8f;
        }
        void Update () {
    
    		if (timer1 == 0);
    		{
    			teleport = 0;
    		}
    
    		if (timer1 == 1);
    		{
    			timecountdown -= Time.deltaTime;
    
    			if (timecountdown <= 0.0f);
    			{
    				teleport = 1;
    				timer1 = 0;
    				timecountdown = 8f;
    			}
    
    		}
    	}
    	void OnTriggerEnter() {
    		//timecountdown = 8f;
    		timer1 = 1;
    	}
    
    	void OnTriggerExit() {
    		timer1 = 0;
    	}
    }
