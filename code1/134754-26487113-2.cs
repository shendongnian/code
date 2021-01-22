    public static IQueryable<T> Page<T, TResult>(this IQueryable<T> obj, int page, int pageSize, System.Linq.Expressions.Expression<Func<T, TResult>> keySelector, bool asc, out int rowsCount)
    {
        rowsCount = obj.Count();
        int innerRows = rowsCount - (page * pageSize);
        if (innerRows < 0)
        {
            innerRows = 0;
        }
        if (asc)
            return obj.OrderByDescending(keySelector).Take(innerRows).OrderBy(keySelector).Take(pageSize).AsQueryable();
        else
            return obj.OrderBy(keySelector).Take(innerRows).OrderByDescending(keySelector).Take(pageSize).AsQueryable();
    }
    
    public IEnumerable<Data> GetAll(int RowIndex, int PageSize, string SortExpression)
    {
        int totalRows;
        int pageIndex = RowIndex / PageSize;
    
        List<Data> data= new List<Data>();
        IEnumerable<Data> dataPage;
    
        bool asc = !SortExpression.Contains("DESC");
        switch (SortExpression.Split(' ')[0])
        {
            case "ColumnName":
                dataPage = DataContext.Data.Page(pageIndex, PageSize, p => p.ColumnName, asc, out totalRows);
                break;
            default:
                dataPage = DataContext.vwClientDetails1s.Page(pageIndex, PageSize, p => p.IdColumn, asc, out totalRows);
                break;
        }
    
        foreach (var d in dataPage)
        {
            clients.Add(d);
        }
    
        return data;
    }
    public int CountAll()
    {
        return DataContext.Data.Count();
    }
