    public abstract class Character
    {
        public virtual void Attack(Character target)
        {
            HitTest ht = new HitTest();
            if (ht.CanHit(this, target))
            {
                DamageCalculator dc = new DamageCalculator();
                int damage = dc.GetDamage(this, target);
                target.TakeDamage(damage);
            }
        }
    }
