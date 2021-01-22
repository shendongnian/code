    var strings = new MyStringList();
    strings.Add("Hello");
    strings.Add("Goodbye");
    
    var objects = (List<object>)strings;
    objects.Add(new Random());
    
    foreach (string s in strings)
    {
        Console.WriteLine("Length of string: {0}", s.Length);
    }
