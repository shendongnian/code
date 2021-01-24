    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class ProximityTeleport : MonoBehaviour {
        public float time;
        //public int timer1 = 0;
    	public bool triggerActive = false;
        public int teleport = 0;
        public float timecountdown;   
    
        void Start () {
    		timecountdown = 8.0f;
    	}
        void Update () {
    		if (triggerActive)
    		{
    			timecountdown -= Time.deltaTime;
    			if (timecountdown <= 0.0f)
    			{
    				timecountdown = 8.0f;
    				teleport = 1;
    				
    				// player has to re-enter the trigger:
    				triggerActive = false;
    			}
    
    		} else {
    			teleport = 0;
                timecountdown = 8.0f;
    		}
    	}
    	
        void OnTriggerEnter() {
            triggerActive = true;
        }
    
        void OnTriggerExit() {
            triggerActive = false;
        }
    }
