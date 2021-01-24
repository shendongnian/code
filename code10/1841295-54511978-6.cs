    public class WeakHealth : Health
    {
        // Since it is abstract we have to implement Die
        public override void Die()
        {
            // whatever happens here
        }
        // Now we replace the TakeDamage
        public override void TakeDamage()
        {
            // by not calling base.TakeDamage we don't execute the base implementation at all
            Debug.Log("Huge Ouch!");
            health -= 10;
        }
    }
