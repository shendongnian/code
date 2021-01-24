        if (DataStrings != null)
    {
        foreach(string Dataline in DataStrings)
        {
	    var attack = new Attack();
            attack  = JsonUtility.FromJson<Attack>(DataStrings[i]);
            Attacks.Add(attack)
        }
    }
