    List<int> ints = new List<int>();
    
    foreach (char c in result.ToCharArray())
    {
        ints.Add(Int32.Parse(c.ToString()));
    }
