    if (Itemlist.ContainsKey(key))
    {
        string value = Itemlist[key];
    
        string[] split = value.Split('-');
    
        string label = split[0].Trim();
        double price = double.Parse(split[1]);
        
        // do something
    }
    else
    {
        // do something?
    }
