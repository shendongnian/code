    public class A
    {
        public virtual int TakeDamage(int damageTaken) { ... }
    }
    
    public class B : A
    {
        public override int TakeDamage(int damageTaken)
        {
            // Non-base stuff
    
            // Base stuff
            base(damageTaken);
        }
    }
