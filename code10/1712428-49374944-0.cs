    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class KeyboardButton : MonoBehaviour {
    
        public static int controller;
    	public AnotherScript anotherScript;
    	
    	Start()
    	{
    		anotherScript = GameObject.Find("Name of Object").GetComponent<AnotherScript>();
    	}
    	
    	
        public void buttonClick () {
            controller = 1;
    		
    		anotherScript.sendValue(controller); //send your value to another script
        }
    }
