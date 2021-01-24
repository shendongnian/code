    class Names
    {
       public List<string> NamesList { get; set; }
    }
    
           ...
            
    for (int i = 1; i <= 5; i++)
    {
        var result += NamesList[i];
        ...
    }
