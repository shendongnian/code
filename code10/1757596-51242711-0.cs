    public static int CountOverlapping(this IQueryable<Table1Row> table1,
        DateTime startCheckDate,
        DateTime endCheckDate)
    {
        return table1
            .Where (row => row.StartDate < startCheckDate && row.EndDate > endCheckDate)
            .Count();
    }
