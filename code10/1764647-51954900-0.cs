    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    public class EventHandler : MonoBehaviour {
        public GameObject MainPlane;
        public GameObject DestroyedPlane;
        public GameObject p;
        public int Got;
    	private void Start()
    	{
            Instantiate(p);
    	}
    	private void Update()
    	{
            MainPlane = GameObject.Find("Plane");
            if(MainPlane!=null){
                if(Got==0){
                    MainPlane.name = "MainPlane";
                    Got = 1;
                }
                if(Got==1){
                    MainPlane = null;
                    DestroyedPlane = GameObject.Find("Plane");
                    Destroy(DestroyedPlane);
                }
            }
    	}
    }
