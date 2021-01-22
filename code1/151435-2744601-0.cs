    public List<T> GetListFromTable<T>(DataTable table, string colName)
    {
       var list = new List<T>();
       foreach (DataRow row in table)
       {
           list.Add((T)row[colName]);
       }
       return list;
    }
    
    public List<T> GetListFromDataTable<T>(DataSet ds, string tableName)
    {
        return GetListFromTable(ds.Tables[tableName]);
    }
