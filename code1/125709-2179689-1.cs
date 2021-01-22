    public void Process(Character myCharacter)
    {
        ...
        ICanAttack attacker = null;
        if ((attacker = (myCharacter as ICanAttack)) != null) attacker.Attack(anotherCharacter);
    }
