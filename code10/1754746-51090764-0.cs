    If you are looking for an object in your scene, then use this simple script;
    
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class AnswerScript : MonoBehaviour {
    
    
        private Transform lookAt;
    
    
    	// Use this for initialization
    	void Start () {
            lookAt.Find("The Object That You are Looking For");
    	}
    	
    	// Update is called once per frame
    	void Update () {
    		
    	}
    }
