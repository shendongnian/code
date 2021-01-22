    using (var sticky = new StickyEnumerable<int>(Enumerable.Range(1, 10)))
    {
        var first = sticky.Take(2);
        var second = sticky.Take(2);
        foreach (int i in second)
        {
            Console.WriteLine(i);
        }
        foreach (int i in first)
        {
            Console.WriteLine(i);
        }
    }
