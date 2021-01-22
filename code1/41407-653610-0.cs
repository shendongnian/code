    List<int> ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    ints.RemoveWhere(i => i > 5);
    foreach (int i in ints)
    {
        Console.WriteLine(i);
    }
