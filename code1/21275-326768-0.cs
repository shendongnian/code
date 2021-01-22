    Hashtable table = new Hashtable(); // ps, I would prefer the generic dictionary..
    Hashtable updates = new Hashtable();
    
    foreach (DictionaryEntry entry in table)
    {
       // logic if something needs to change or nog
       if (needsUpdate)
       {
          updates.Add(key, newValue);
       }
    }
    
    // now do the actual update
    foreach (DictionaryEntry upd in updates)
    {
       table[upd.Key] = upd.Value;
    }
