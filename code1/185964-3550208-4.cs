    var strings = new List<string>();
    
    // If this cast were possible...
    var objects = (List<object>)strings;
    
    // ...crap! then you could add a DateTime to a List<string>!
    objects.Add(new DateTime(2010, 8, 23));
