    public class DamageCalculator
    {
        public DamageCalculator()
        {
            this.Battle = new DefaultBattle();
            // Better: use an IoC container to figure this out.
        }
        public DamageCalculator(Battle battle)
        {
            this.Battle = battle;
        }
        public int GetDamage(Character source, Character target)
        {
            // ...
        }
        protected Battle Battle { get; private set; }
    }
