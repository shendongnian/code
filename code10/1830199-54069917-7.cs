    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Fighting : MonoBehaviour 
    {
        public int Team = 1;
        public int Health = 100;
        public int AttackDamage = 10;
        public float CoolDown = 2;
        public float original = 2;
        
        // you don't need that flag see below
        //public bool CoolingDown = false;
        public bool Snap = false;
    
        private void Update()
        {
            // you might also put this in a callback instead of update at some point later
            if(Snap == true)
            {
                Destroy(transform.parent.gameObject);
            }
            // Note: this also makes not muh sense because if you destroyed
            // the parent than you cannot instantiate it again!
            // use a prefab instead
            if (Input.GetKey(KeyCode.N)) Instantiate(transform.parent.gameObject);
        }
    
        public void TakeDamge(int DamageAmount)
        {
            Health -= DamageAmount;
    
            if (Health > 0) return;
            
            Destroy(transform.parent.gameObject);
        }
    }
