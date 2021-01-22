    protected int CalculateDamage(Character target)
    {
        int baseDamage = Strength * 2 + Weapon.DamageRating;
        int armorReduction = target.Armor.ArmorRating;
        int physicalDamage = baseDamage - Math.Min(armorReduction, baseDamage);
        int pierceDamage = (int)(Weapon.PierceDamage / target.Armor.PierceResistance);
        int elementDamage = (int)(Weapon.ElementDamage /
            target.Armor.ElementResistance[Weapon.Element]);
        int netDamage = physicalDamage + pierceDamage + elementDamage;
        if (HP < (MaxHP * 0.1))
            netDamage *= DesperationMultiplier;
        if (Status.Berserk)
            netDamage *= BerserkMultiplier;
        if (Status.Weakened)
            netDamage *= WeakenedMultiplier;
        int randomDamage = Random.Next(netDamage / 2);
        return netDamage + randomDamage;
    }
