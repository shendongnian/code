    var h1 = new HashSet<char>();
    var h2 = new HashSet<char>();
    foreach (var ch in "nbHHkRvrXbvkn")
    {
        if (!h1.Add(ch))
        {
            h2.Add(ch);
        }
    }
    h1.ExceptWith(h2); // remove duplicates
    var chars = new char[h1.Count];
    h1.CopyTo(chars);
    var result = new string(chars); // = "RrX"
