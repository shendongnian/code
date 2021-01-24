    int proprtyCount = dictionary.Keys.Count;
    var classCustomList = new List<ClassCustom>();
    foreach (KeyValuePair<object, object> pair in dictionary)
    {
         classCustomList.Add(new ClassCustom(pair.Key, pair.Value));
    }
    
    SomeCollection collection = new SomeCollection(classCustomList);
