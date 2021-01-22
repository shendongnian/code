    public static DataRow NewRow<T>(this DataTable dataTable, List<T> columnValues, Func<T, string> itemArrayCriteria)
    {
        DataRow returnValue = dataTable.NewRow();
    
        while (columnValues.Count > returnValue.Table.Columns.Count)
        {
            returnValue.Table.Columns.Add();
        }
    
        returnValue.ItemArray = columnValues.Select(x => itemArrayCriteria(x)).ToArray();
        return returnValue;
    }
