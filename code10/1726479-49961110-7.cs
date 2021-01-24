    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class Resources : MonoBehaviour
    {
        public float maxHealth = 5;
        public float currentHealth;
        public float ResourceCounter;
        public Inventory inventory;
        public Texture stoneIcon;
        public Texture woodIcon;
        void Start()
        {
            currentHealth = maxHealth;
            ResourceCounter = 0;
        }
        void Update()
        {
            Die();
        }
        public void OnMouseOver()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Loosing one health");
                currentHealth = currentHealth - 1f;
            }
        }
        public void Die()
        {
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                inventory.ResourceStone++;
            }
        }
    }
