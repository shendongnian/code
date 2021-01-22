    foreach (var row in groups.GroupBy(g => g.Key.EventName))
    {
        foreach (var month in row.GroupBy(g => g.Key.Month))
        {
            var value = month.Count();
        }
    }
