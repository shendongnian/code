    List<dynamic> list = myList
                   .GroupBy(a => a.WorkOrderID )
                   .OrderByDescending(b => b.LastUpdatedAt)
                   .Select(g => g.FirstOrDefault())
                   .ToList();
    foreach (var p in list)
    {
        Console.WriteLine(p.WorkOrderID + " : " + p.Col3);
    }
