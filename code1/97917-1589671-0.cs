    List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };
    
    IEnumerable<IGrouping<int,int>> groups =
       list
       .Select((n, i) => new { Group = i / 2, Value = n })
       .GroupBy(g => g.Group, g => g.Value);
    
    foreach (IGrouping<int, int> group in groups) {
       Console.WriteLine(String.Join(", ", group.Select(n=>n.ToString()).ToArray()));
    }
