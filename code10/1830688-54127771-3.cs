       using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using System.Runtime.InteropServices;
        using UnityEngine.SceneManagement;
        public class SceneChanger : MonoBehaviour {
        
        	// Use this for initialization
        	void Start () {
        		
        	}
        	
        	// Update is called once per frame
        	void Update () {
        		//SceneManager.LoadScene(scene);
    // try your script................
        	}
        
        
        public void ChangeScene( string scene ) {
           // Application.LoadLevel(scene);
            SceneManager.LoadScene(scene);
        }
        }
