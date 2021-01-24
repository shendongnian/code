    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class TriggerScript : MonoBehaviour {
        private ChangeTextScript changeTextScript;
    
        void Start() {
            changeTextScript = GameObject.Find("CountdownText").GetComponent<ChangeTextScript>();
        }
    
        void OnTriggerEnter()
        { 
            changeTextScript.StartChangingText();
        }
    
        void OnTriggerExit()
        {
            changeTextScript.ResetText();
        }
    }
