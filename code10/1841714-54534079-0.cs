    using UnityEngine;
    using UnityEngine.UI;
    
    public class Health : MonoBehaviour
    {
        public Text HealthText;
        public Slider HealthSlider;
    
        public float MaxHealth = 100;
        public float CurrentHealth = 100;
    
        public void TakeDamage()
        {
            if (CurrentHealth > 0)
            {
                CurrentHealth -= Time.deltaTime * 10;
            }
        }
    
        private void Update()
        {
            HealthUI();
        }
    
        public void HealthUI()
        {
            HealthSlider.value = CurrentHealth / MaxHealth;
            HealthText.text = "HEALTH " + ((int)(CurrentHealth / MaxHealth * 100)).ToString() + "%";
        }
    }
