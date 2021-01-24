    var l1 = new List<string>();
    List<string> l2;
    l1.Add("One");
    l1.Add("Two");
    l2 = l1;
    l1 = new List<string>();
    l1.Add("Three");
    Console.WriteLine("L1:");
    foreach (var elem in l1)
    {
        Console.WriteLine(elem);
    }
    Console.WriteLine("L2:");
    foreach (var elem in l2)
    {
        Console.WriteLine(elem);
    }
