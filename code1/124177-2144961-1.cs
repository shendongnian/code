    public abstract class Character
    {
        public const int BaseHitChance = 30;
        public virtual void Attack(Character target)
        {
            int chanceToHit = Dexterity + BaseHitChance;
            int hitTest = Random.Next(100);
            if (hitTest < chanceToHit)
            {
                int damage = Strength * 2 + Weapon.DamageRating;
                target.TakeDamage(damage);
            }
        }
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public Weapon Weapon { get; set; }
    }
