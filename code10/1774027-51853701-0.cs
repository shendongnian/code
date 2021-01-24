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
            float currentDis;
            currentDis = distance;
    
            if (currentDis - oldDis >= 10)
            {
                Debug.Log("Raised up by 10 and now it's " + currentDis + " !!!");
                oldDis = currentDis;
            } 
        }
    }
