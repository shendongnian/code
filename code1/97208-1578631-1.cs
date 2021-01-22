    public bool DoesColumnExist(IDataReader reader, string columnName)
    {
         reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName= '"  + columnName +  "'";  
         return (reader.GetSchemaTable().DefaultView.Count > 0);
    }
