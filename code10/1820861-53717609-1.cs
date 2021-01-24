    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class powerUpList : MonoBehaviour
    {
        private List<powerUps> powerUpsList;
        void Start()
        {
            powerUpsList = new List<powerUps>();
            powerUpsList.Add(new powerUps("fire", 5));
            powerUpsList.Add(new powerUps("static", 3));
            powerUpsList.Add(new powerUps("shield", 0));
            powerUpsList.Add(new powerUps("repel", 0));
            powerUpsList.Add(new powerUps("repairKit", 0));
            powerUpsList.Add(new powerUps("thorns", 3));
            powerUpsList.Add(new powerUps("bearBooster", 1));
            powerUpsList.Sort();
        }
   
        void OnTriggerEnter(Collider player)
        {
            powerUps RandomPowerup = powerUpsList[Random.Range(0, powerUpsList.Count)];
        }
    }
