    List<TableName> tableNames = new List<TableName> {
        new TableName { Number = 2},
        new TableName { Number = 4},
        new TableName { Number = 3},
        new TableName { Number = 3},
        new TableName { Number = 2},
        new TableName { Number = 3},
        new TableName { Number = 4},
        new TableName { Number = 4},
        new TableName { Number = 4},
        new TableName { Number = 4}
    };
    IEnumerable<int> runningSum = tableNames.Select(r => (tableNames.Where(ri => ri.Number <= r.Number).Sum(rii => rii.Number))).OrderBy(num => num);
