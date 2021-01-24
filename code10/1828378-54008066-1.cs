    var result = tables.Select(table => 
    {
        var columnTasks = table.Select(column => GetColumnContraintsAsync(...)).ToArray();
        // all tasks are running now, wait until all are completed:
        await Task.WhenAll(columnTasks);
        // fetch the result from every task:
        var columnTaskResults = columnTasks.Select(columnTask => columnTask.Result).ToList();
        // create a Table with these results and return it:
        return new Table
        {
            Columns = columnTaskResults,
        };
    })
    .ToList();
