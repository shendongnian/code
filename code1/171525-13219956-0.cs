    CompositeCollection cc = new CompositeCollection();
    
    cc.Add(1);
    cc.Add("Item One");
    cc.Add(1.0M);
    cc.Add(1.0);
    cc.Add("Done");
    
    Console.WriteLine ("Every Item");
    
    foreach (var element in cc)
        Console.WriteLine ("\t" + element.ToString());
    
    Console.WriteLine (Environment.NewLine + "Just Strings");
    
    foreach (var str  in cc.OfType<string>())
        Console.WriteLine ("\t" + str);
    
    /* Outputs:
    
    Every Item
      1
      Item One
      1.0
      1
      Done
    
    Just Strings
      Item One
      Done
    
    */
