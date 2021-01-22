    List<string> sl = new List<string>();
    // Add strings to sl
    
    List<object> ol = new List<object>();
    
    foreach(string s in sl)
    {
        ol.Add((object)s);  // The cast is performed implicitly even if omitted
    }
