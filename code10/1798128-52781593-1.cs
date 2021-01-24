    public static DataTable GetSortedTable(DataTable dt, string sort)
    {
        dt.DefaultView.Sort = sort;
        return dt.DefaultView.ToTable();
    }
    
