    public class Enemy : MonoBehaviour
    {
        int health;
    
        public void TakeDamage(int amount)
        {
            health -= amount;
        }
    }
    
