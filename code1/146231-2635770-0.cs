    Hashtable clone(Hashtable input)
    {
        Hashtable ret = new Hashtable();
        foreach (DictionaryEntry dictionaryEntry in input)
        {
            if (dictionaryEntry.Value is string)
            {
                ret.Add(dictionaryEntry.Key, new string(dictionaryEntry.Value.ToString().ToCharArray()));
            }
            else if (dictionaryEntry.Value is Hashtable)
            {
                ret.Add(dictionaryEntry.Key, clone((Hashtable)dictionaryEntry.Value));
            }
            else if (dictionaryEntry.Value is ArrayList)
            {
                ret.Add(dictionaryEntry.Key, new ArrayList((ArrayList)dictionaryEntry.Value));
            }
        }
        return ret;
    }
