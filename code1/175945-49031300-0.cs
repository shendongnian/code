    OrderColumn[] columnsToOrderby = getColumnsToOrderby();
    IQueryable<T> data = getData();
    if(!columnToOrderBy.Any()) { }
    else
    {
        OrderColumn firstColumn = columnsToOrderBy[0];
        IOrderedEnumerable<T> orderedData =
            firstColumn.Ascending
            ? data.OrderBy(predicate)
            : data.OrderByDescending(predicate);
        for (int i = 1; i < columnsToOrderBy.Length; i++)
        {
            OrderColumn column = columnsToOrderBy[i];
            orderedData =
                column.Ascending
                ? orderedData.ThenBy(predicate)
                : orderedData.ThenByDescending(predicate);
        }
    }
