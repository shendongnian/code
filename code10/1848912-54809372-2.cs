    public class A
    {
        public int TakeDamage(int damageTaken) { ... }
    }
    
    public class B
    {
        public int AnotherMethod(int damage)
        {
            gameObject.GetComponent<A>().TakeDamage(damage);
        }
    }
