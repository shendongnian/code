    var rowsInOrder = new List<string>();
    foreach (var grouping in dates.GroupBy(s =>
            DateTime.ParseExact(s, "yyyyMM", CultureInfo.CurrentCulture).Month))
    {
        rowsInOrder.AddRange(grouping.OrderBy(s => s));
    };
