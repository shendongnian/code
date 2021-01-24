    var businessObject = new BuissnessObject();
                
    var dic = new Dictionary<string, string>()
    {
        {"Foo", "value1" },
        {"Bar", "value2" },
    };
    // Get property array
    var properties = GetProperties(businessObject);
    foreach (var p in properties)
    {
        string name = p.Name;
        
        // Skip what you want to skip
        if(myListOfIgnoredProp.Contains(name))
            continue;
        // Feed what you want to feed
        if (dic.TryGetValue(name, out var value))
        {
            if(p.PropertyType == typeof(string))
                p.SetValue(businessObject, value);
            else if (p.PropertyType == typeof(bool))
                p.SetValue(businessObject, bool.Parse(value));
            //And so on...
        }
    }
