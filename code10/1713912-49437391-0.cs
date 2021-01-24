    // building data
    var source = new ThisThing() { Cells = new List<Cell>() };
    var f1 = new[] { "100", "200", "300", "400", "500", "100", "600", "700", "800", "100" };
    var f2 = new[] { "A", "A", "A", "A", "A", "A", "A", "A", "A", "A" };
    var f3 = new[] { "A", "A", "A", "A", "A", "B", "A", "A", "A", "A" };
    for (int i = 1; i <= 10; i++) {
        source.Cells.Add(new Cell() { RowNumber = i, ColumnName = "F1", ColumnValue = f1[i - 1] });
        source.Cells.Add(new Cell() { RowNumber = i, ColumnName = "F2", ColumnValue = f2[i - 1] });
        source.Cells.Add(new Cell() { RowNumber = i, ColumnName = "F3", ColumnValue = f3[i - 1] });
    }
    // normalize, same as in SQL query
    // note we do not materialize query yet
    var normalized = source.Cells.Select(c => new {
        c.RowNumber,
        F1 = c.ColumnName == "F1" ? c.ColumnValue : null,
        F2 = c.ColumnName == "F2" ? c.ColumnValue : null,
        F3 = c.ColumnName == "F3" ? c.ColumnValue : null
    });
    // flatten, again literal transaction
    // still query is not executed
    var flattened = normalized.GroupBy(c => c.RowNumber).Select(c => new {
        RowNumber = c.Key,
        F1 = c.Max(r => r.F1),
        F2 = c.Max(r => r.F2),
        F3 = c.Max(r => r.F3),
    });
    // again almost literal transaction
    // at the end, query is finally executed with ToArray()
    var result = flattened
        .GroupBy(c => new { c.F1, c.F2, c.F3 })
        .Where(c => c.Count() > 1)
        .SelectMany(c => c.Select(r => r.RowNumber)).ToArray();
