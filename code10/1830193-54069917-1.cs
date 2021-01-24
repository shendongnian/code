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
        public bool CoolingDown = false;
        public bool Snap = false;
    
        private void Update()
        {
            // Note: this also makes not muh sense because if you destroyed
            // the parent than you cannot instantiate it again!
            // use a prefab instead
            if (Input.GetKey(KeyCode.N)) Instantiate(transform.parent.gameObject);
        }
    
        public void TakeDamge(int DamageAmount)
        {
            Health -= DamageAmount;
    
            if (Snap == true || Health <= 0)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
