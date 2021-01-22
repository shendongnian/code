    public yourClass GetDesiredObject(string lkupValue)
    {
      if (yourCachedHashtable.ContainsKey(lkupValue))
      {
         return yourCachedHashtable[lkupValue]
      }
      else
      {
         //Hit the db to retrieve the object values.
         yourClass obj = yourDatabaseCode.GetNewObject(lkupValue);
         //Add to the cache if desired.
         yourCachedHashtable.Add(lkupValue, obj);
         return obj;
      }
    }
