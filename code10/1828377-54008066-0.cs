    var columnConstraints = await GetColumnConstraintsAsync();
    var result = tables.Select(table => new Table
    {
        Columns = table.Select(column => new Column
        {
            Constraints = columnConstraints,
            ...
        })
    })
    .ToList();
