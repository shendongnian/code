    // a Set might be better -- I don't know what you're using this for
    var myDict = new Dictionary<string, BaseItem>();
    // ...
    if (currentAmount + item.Weight <= maxAmount)
    {
        if (myDict.ContainsKey(item.Name))
        {
            Console.WriteLine("Item already exists");
            item.Quantity++;
        }
        else
        {
            Console.WriteLine("Adding new item");
            myDict[item.Name] = item;
        }
    
        currentAmount += item.Weight;
    }
    else
    {
        Console.WriteLine("Full");
    }
