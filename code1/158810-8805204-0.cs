    IDictionary<int, object> a = new Dictionary<int, object>();
    IDictionary<int, object> b = new Dictionary<int, object>();
    a.Add(1, "1");
    a.Add(2, 2);
    a.Add(3, "3");
    
    b.Add(3, "3");
    b.Add(1, "1");
    b.Add(2, 2);
    
    Console.WriteLine(a.All(i => b.Contains(i)) && b.All(i => a.Contains(i)));
