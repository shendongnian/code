    int sum = 0;
    List<TableName> tableNames = new List<TableName> {
        new TableName { Number = 1},
        new TableName { Number = 2},
        new TableName { Number = 4},
        new TableName { Number = 8},
        new TableName { Number = 12},
    };
    tableNames.ForEach(t => Console.WriteLine(sum = t.Number + sum));
