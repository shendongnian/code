    var result = someList.Select(async table =>
    {
        var columnTasks = table.Select(async column => new Column()
        {
            Constraints = await GetColumnConstraints()
        });
        var columns = await Task.WhenAll(columnTasks);
        return new Table()
        {
            Columns = columns
        };
    });
