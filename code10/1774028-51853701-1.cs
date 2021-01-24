    using System.Collections;
    using UnityEngine;
    
    public class GameManager : SingleTon<GameManager> {
        private float oldDis;
    
        void Start()
        {
            oldDis = distance;
        }
    
        // Update is called once per frame
        void Update ()
        {
    
            if (distance - oldDis >= 10)
            {
                Debug.Log("Raised up by 10 and now it's " + distance + " !!!");
                oldDis = distance;
            } 
        }
    }
