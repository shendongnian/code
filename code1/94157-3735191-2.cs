    public DataTable GetSchema(params string[] columns)
    {
        string col_list;
        if (columns.Length == 0)
            col_list = "*";
        else
            col_list = String.Join(", ", columns);
        return Provider.QueryAsDataTable(string.Format("select top 0 {0} from customers", col_list));
    }
