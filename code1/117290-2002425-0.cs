    var v = new ListableItem("Jim");
    var items = new Dictionary<String, IListable>();
    items.Add(v.Name, v);
    
    IListable result;
   
    result = items["Jim"];  // Throws KeyNotFoundException
    if (!items.TryGetValue("Jim", out result))
    {
        // Jim is not in the dictionary
    }  
