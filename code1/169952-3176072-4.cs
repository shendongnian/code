    List<int> l = new List<int>{89, 67, 34, 11, 34};
    foreach (IEnumerable<int> group in l.Grouped(2)) {
        string s = string.Join(", ", group.Select(x => x.ToString()).ToArray());
        Console.WriteLine(s);
    }
