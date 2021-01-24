    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class TrigDetect : MonoBehaviour
    {
        bool once = false; 
    
        private Fighting myFighting;
    
        private void Awake()
        {
            myFighting = GetComponent<Fighting>();
        }
    
        void OnTriggerStay(Collider other)
        {
            // if wrong tag do nothing
            if (!other.CompareTag("Troop")) return;
    
            Fighting fScript = other.GetComponent<Fighting>();
    
            // here you should add a check
            if(!fScript)
            {
                // By using the other.gameObject as context you can find with which object
                // you collided exactly by clicking on the Log
                Debug.LogError("Something went wrong: Could not get the Fighting component of other", other.gameObject);
            }
            if (!once)
            {
                Debug.Log("I am the team:" + self.Team);
                Debug.Log("I have detected the team:" + fScript.Team);
                once = true;
            }
    
            // if same team do nothing
            if (self.Team == fScript.Team) return;
            
            // you don't need the CoolingDown bool at all:
            self.CoolDown -= Time.deltaTime;
    
            // if still cooling down do nothing
            if(self.CoolDown > 0) return;
            
            fScript.TakeDamage(self.AttackDamage);
            self.CoolDown = self.original;
        }
    }
