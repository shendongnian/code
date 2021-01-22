    public static IGrouping<object[], object[]> GroupByIndexes(
        this IEnumerable<object[]> source,
        params int[] indexes)
    {
        return source.GroupBy(row => row, new ColumnComparer(indexes));
    }
    // Usage
    row.GroupByIndexes(0, 1, 2)
