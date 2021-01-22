    // note that the delegate can be declared either in a class or outside of it.
    public delegate int Damage(float randomSample);
    public class CombatantGameModel /* ... */
    {
        /* ... */
        public Damage DamageCalculator { get; set; }
    }
