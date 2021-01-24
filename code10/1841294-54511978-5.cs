    public class NormalHealth : Health
    {
        // since it is abstract we have to implement Die
        public override void Die()
        {
            // whatever happens here
        }
        // But if we want to use the default TakeDamage we just do nothing
    }
