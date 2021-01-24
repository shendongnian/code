    int proprtyCount = dictionary.Keys.Count;
    SomeCollection collection = new SomeCollection();
    foreach (KeyValuePair<object, object> pair in dictionary)
    {
         collection.Add(new ClassCustom(pair.Key, pair.Value));
    }
    
