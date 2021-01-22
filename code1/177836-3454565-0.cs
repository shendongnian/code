    // using System.Collections.Specialized;
    
    foreach (Table table in database.Tables)
    {
        StringCollection pk_script = new StringCollection();
    
        Index pk = table.Indexes.Cast<Index>().SingleOrDefault(index => index.IndexKeyType == IndexKeyType.DriPrimaryKey);
        if (pk != null)
        {
            pk_script = pk.Script();
            pk.Drop();
            table.Alter();
        }
        foreach (Column column in table.Columns.Cast<Column>().Where(column => column.DataType.SqlDataType == SqlDataType.Char))
        {
            column.DataType = new DataType(SqlDataType.VarChar, column.DataType.MaximumLength);
        }
        table.Alter();
        foreach (String tsql in pk_script)
        {
            database.ExecuteNonQuery(tsql);
        }                
    } 
