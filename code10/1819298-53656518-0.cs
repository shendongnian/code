    static void Main(string[] args)
    {
        var data = new List<string>
        {
            "test",
            "test",
            "test",
            "test",
            "test1",
            "test1",
            "test2",
            "test2",
            "test2",
            "test2",
            "test2",
            "test2",
        };
        var groups = data.GroupBy(x => x).OrderByDescending(x => x.Count());
        var maxGroupCount = groups.Max(g => g.Count());
        var orderedData = new List<string>();
        for (int i = 0; i < maxGroupCount; i++)
        {
            foreach (var group in groups)
            {
                if (group.Count() > i)
                {
                    orderedData.Add(group.ElementAt(i));
                }
            }
        }
        orderedData.ForEach(Console.WriteLine);
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
