    Dictionary<string, int> collection = new Dictionary<string, int>();
    collection.Add("value1", 9);
    collection.Add("value2", 7);
    collection.Add("value3", 5);
    collection.Add("value4", 3);
    collection.Add("value5", 1);
    
    for (int i = collection.Keys.Count; i-- > 0; ) {
        if (collection.Values.ElementAt(i) < 5) {
            collection.Remove(collection.Keys.ElementAt(i)); ;
        }
    
    }
