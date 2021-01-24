    //Assuming the dictionary is something like Dictionary<string, object>
    
    var query = new Query("Posts");
    
    foreach(var element in dictionary)
    {
        query = query.Where(element.Key, element.Value);
    }
    
    var result = query.Get();
