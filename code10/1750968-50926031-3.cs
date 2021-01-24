    Dictionary<int, string> data = new Dictionary<int, string>
    {
        { 1, "Red" }, 
        { 4, "Blue" },
        { 13, "Green" }
    };
    
    string test;
    if (data.TryGetValue(1, out test)) // Returns true.
    {
       Console.WriteLine(test); 
    }
