    private static void Main()
    {
        var filters = new List<Filter>
        {
            new Filter {ColumnName = "LoanNum", ColumnValue = "1234"},
            new Filter {ColumnName = "Dates", ColumnValue = "01/01/2019"},
            new Filter {ColumnName = "LoanNum", ColumnValue = "456"},
            new Filter {ColumnName = "Dates", ColumnValue = "01/02/2019"},
            new Filter {ColumnName = "LoanNum", ColumnValue = "55676"},
        };
        var query = $"SELECT LOANS WHERE {CreateWhereClause(filters)}";
        Console.WriteLine(query);
        Console.ReadKey();
    }
