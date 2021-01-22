    private static DataTable SortDataTable(DataTable t, 
       string filterExpression,
       string sortExpression)
    {
        DataTable t1 = t.Clone();
        t1.BeginLoadData();
        foreach (DataRow r in t.Select(filterExpression, sortExpression))
        {
            t1.Rows.Add(r.ItemArray);
        }
        t1.EndLoadData();
        return t1;
    }
