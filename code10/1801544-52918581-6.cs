    void InitIDs()
    {
        idToDict.Add(1, Elements[5].GetComponent<ID1>().StartAttack(EnemysInBattle, HeroesInBattle, Attacker));
        idToDict.Add(2, Elements[5].GetComponent<ID2>().StartAttack(EnemysInBattle, HeroesInBattle, Attacker));
        idToDict.Add(3, Elements[5].GetComponent<ID3>().StartAttack(EnemysInBattle, HeroesInBattle, Attacker));
        idToDict.Add(4, Elements[5].GetComponent<ID4>().StartAttack(EnemysInBattle, HeroesInBattle, Attacker));
        idToDict.Add(5, Elements[5].GetComponent<ID5>().StartAttack(EnemysInBattle, HeroesInBattle, Attacker));
    }
