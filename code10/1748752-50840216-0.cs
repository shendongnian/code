        public class HealthComponent : MonoBehaviour
        {
            [SerializeField]
            private int _maxHealth;
        
            [SerializeField]
            private int _currentHealth;
        
            public delegate void HealthChanged();
            public event HealthChanged HealthChangedEvent;
        
            public void ChangeHealth(int amountToChangeBy)
            {            
                _currentHealth += amountToChangeBy;
                if (_currentHealth > _maxHealth)
                {
                    _currentHealth = _maxHealth;
                }
                if (_currentHealth < 0)
                {
                    _currentHealth = 0;
                }
                if (HealthChangedEvent != null)
                {
                    HealthChangedEvent();
                }
            }
        }
