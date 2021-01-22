    public abstract class Character
    {
        public virtual void Attack(Character target)
        {
            int damage = Random.Next(1, 20);
            target.TakeDamage(damage);
        }
        public virtual void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP <= 0)
                Die();
        }
        protected virtual void Die()
        {
            // Doesn't matter what this method does right now
        }
        public int HP { get; private set; }
        public int MP { get; private set; }
        protected Random Random { get; private set; }
    }
