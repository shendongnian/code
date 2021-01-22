    Dictionary<int, SomeObject>  myDictionary = new Dictionary<int, SomeObject>();
    
    foreach (var pair in myDictionary.OrderByDescending(i => i.Key))
    {
        //Observe pair.Key
        //Do stuff to pair.Value
    }
