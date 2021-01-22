    public void Attack(Character target)
    {
        int chanceToHit = CalculateHitChance(target);
        int hitTest = Random.Next(100);
        if (hitTest < chanceToHit)
        {
            int damage = CalculateDamage(target);
            target.TakeDamage(damage);
        }
    }
    protected int CalculateHitChance(Character target)
    {
        return Dexterity + BaseHitChance - target.Evade;
    }
    protected int CalculateDamage(Character target)
    {
        return Strength * 2 + Weapon.DamageRating - target.Armor.ArmorRating -
            (target.Toughness / 2);
    }
