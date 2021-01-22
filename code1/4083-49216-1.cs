    // Adding value to existing list
    var list = new List<int>();
    list.AddRange(Enumerable.Range(1, x));
    // Creating new list
    var list = Enumerable.Range(1, x).ToList();
