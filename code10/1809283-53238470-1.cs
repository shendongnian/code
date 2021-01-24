    for (int i = 0; i < GenerationCount; i++)
    {
        string listname = "weapon" + i;
        string id = Random.Range(1, 41).ToString();
        List<string>[] _lists = new List<string>[GenerationCount];
        _lists[i] = new List<string>();
        _lists[i].Add(id); 
        _lists[i].Add(weapon.GetName(id)); 
        _lists[i].Add(weapon.GetRarity(id)); 
        _lists[i].Add(weapon.GetType(id)); 
        _lists[i].Add(weapon.GetDmg(id).ToString());
        _lists[i].Add(weapon.GetSpeed(id).ToString()); 
        _lists[i].Add(weapon.GetCost(id).ToString());
        weapons.Add(listname, _lists[i]);
    }
