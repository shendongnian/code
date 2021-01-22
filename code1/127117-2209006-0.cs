    public static DataRow NewRow(this DataTable dataTable, params object[] objects)
    {
        DataRow returnValue = dataTable.NewRow();
    
        while (objects.Length > returnValue.Table.Columns.Count)
        {
            returnValue.Table.Columns.Add();
        }
    
        returnValue.ItemArray = objects;
        return returnValue;
    }
