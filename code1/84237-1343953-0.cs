    var h1 = new HashSet<char>();
    var h2 = new HashSet<char>();
    foreach (var ch in "nbHHkRvrXbvkn")
    {
        if (!h1.Contains(ch))
        {
            h1.Add(ch);
        }
        else
        {
            h2.Add(ch);
        }
    }
    
    var result = new string(h1.Except(h2).ToArray()); // = "RrX"
