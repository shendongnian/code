    var lines = File.ReadAllLines("pathtoyourfile.ini");
    var dict = new Dictionary<string, string>();
    
    foreach(var s in lines)
    {
         var split = s.Split("=");
         dict.Add(split[0], split[1]);
    }
    
