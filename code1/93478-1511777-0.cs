    object[] parts = {"strager", 2};
    string s = String.Format(formatString, parts);
    
    // Later on use parts, converting each member .ToString()
    foreach (object p in parts)
    {
        Console.WriteLine(p.ToString());
    }
