    Ability usedAbility = abilities.FirstOrDefault(x => x.SpellName1 == spellname);
    if(usedAbility != null)
    {
        MyCharacter.UseSpell(usedAbility);
    }
