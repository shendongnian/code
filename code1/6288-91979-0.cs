    foreach (int key in keys)
    {
      if (!MyDataDict.ContainsKey(key))
      {
        if (!MyDuplicatesDict.ContainsKey(key))
          MyDuplicatesDict.Add(key);
      }
      else
        MyDataDict.Add(key); 
    }
