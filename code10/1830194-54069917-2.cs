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
            if (!other.CompareTag("Troop")) return;
    
            Fighting fScript = other.GetComponent<Fighting>();
    
            if (!once)
            {
                Debug.Log("I am the team:" + self.Team);
                Debug.Log("I have detected the team:" + fScript.Team);
                once = true;
            }
    
            if (self.Team == fScript.Team) return;
            
            // you don't need the CoolingDown bool at all:
            self.CoolDown -= Time.deltaTime;
    
    
            if(self.CoolDown > 0) return;
            
            fScript.TakeDamage(self.AttackDamage);
            self.CoolDown = self.original;
        }
    }
