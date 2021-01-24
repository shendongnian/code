    public void UseSpell(Func<Ability, bool> predicate)
    {
        // get all abilities
        var allAbilties = ...;
        // get the one that matches the condition
        var ability = allAbilities.FirstOrDefault(predicate)
    }
