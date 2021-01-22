    var notEven = Enumerable.Range(1,100);
    foreach (int i in Enumerable.Range(1, 50))
    {
        notEven = notEven.Where(s => s != i * 2);
    }
    Console.WriteLine(notEven.Count());
    Console.WriteLine(string.Join(", ", notEven.Select(s => s.ToString()).ToArray()));
