    var l = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6 });
    for (int i = l.Count - 1; i >= 0; i--)
        if (l[i] % 2 == 0)
            l.RemoveAt(i);
    foreach (var i in l)
    {
        Console.WriteLine(i);
    }
