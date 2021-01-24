    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class EX2BoundaryDetect : MonoBehaviour {
    
    	// create a GameObject to represent the player
    	public GameObject playerObject;
    	public bool leaveArea = false;
    	
    	// create an Audio-clip object. This assumes we drag a sound file onto the myclip box in the Inspector.
    	public AudioClip myclip;
    
    	// Use this for initialization
    	void Start () {
    
    		// associate playerObject with the player. This assumes the First Person Controller is name "player
    		playerObject = GameObject.Find ("player");
    
    		// get the actual Sound file from the Inspector
    		GetComponent<AudioSource>().clip = myclip;
    		
    	}
    	
    	// Update is called once per frame
    	void Update () {
    		
    		PlayAudio1();
    		if (leaveArea) {
    			GetComponent<AudioSource> ().Play ();
    		}
    		
    		leaveArea = false;
    	}
    
    	public void PlayAudio1 () {
    		
    		// play the sound if the player is outside some boundaries
    
    		if (transform.position.x > 10) {
    			leaveArea = true;
    		}
    
    		if (transform.position.x < -29) {
    			leaveArea = true;
    		}
    
    		if (transform.position.z > 10) {
    			leaveArea = true;
    		}
    
    		if (transform.position.z < -29) {
    			leaveArea = true;
    		}
    
    		
    		
    	}
    }
