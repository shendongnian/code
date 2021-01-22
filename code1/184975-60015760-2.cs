    DataTable dataTable = new DataTable();
    try
    {
       using (var adapter = new SqlDataAdapter("StoredProcedureName", ConnectionString))
       {
           adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
           adapter.SelectCommand.Parameters.Add("@ParameterName", SqlDbType.Int).Value = 123;
           adapter.Fill(dataTable);
       };
    }
    catch (Exception ex)
    {
        Logger.Error("Error occured while fetching records from SQL server", ex);
    }
