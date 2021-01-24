    var masterQuery = new[]
    {
        new { Name = "Asterix", Weight = 50 },
        new { Name = "Obelix", Weight = 120 },
        new { Name = "Idefix", Weight = 1 }
    }.AsQueryable();
    var wheres = new[]
    {
        new Filtering.WhereParams { ColumnName = "Name", Operator = "Equals", Value = "Asterix" },
        new Filtering.WhereParams { AndOr = "OR", ColumnName = "Name", Operator = "Equals", Value = "Obelix" },
        new Filtering.WhereParams { AndOr = "AND", ColumnName = "Weight", Operator = "LESS THAN", Value = 100 }
    };
    var filtered = masterQuery.Where(wheres).ToList();
    // asterix
