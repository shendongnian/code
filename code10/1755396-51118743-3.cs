        // Sample code
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add("AccountId"); //create column with correct data type
        dataTable.Columns.Add("Amount"); //create column with correct data type
        // Add rows to the table
        ...
    
        // Assuming the connection and command is available.
        SqlParameter tvpParam = sqlCommand.Parameters.AddWithValue("@tvpAccount", dataTable);  
        tvpParam.SqlDbType    = SqlDbType.Structured;  
        tvpParam.TypeName     = "dbo.AccountTableType";  
    
        sqlCommand.ExecuteNonQuery();
