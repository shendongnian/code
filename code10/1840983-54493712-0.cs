    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class ChangeQuestion1 : MonoBehaviour {
    
        public GameObject databaseinterfaceinstance;
    
        public Text Question1;
        public string yourText = "Your text goes here";
        // Use this for initialization
        void Start () {
            databaseinterfaceinstance = GameObject.FindWithTag("DatabaseInterface").GetComponent<GameObject>();
            Question1 = gameObject.GetComponent<Text>();
            Question1.text = yourText;
        }
    
        // Update is called once per frame
        void Update () {
    
        }
    }
