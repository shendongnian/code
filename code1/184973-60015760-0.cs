    DataTable dataTable = new DataTable();
    try
    {
       using (var adapter = new SqlDataAdapter("select command......", ConnectionString))
       {
           adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
           adapter.Fill(dataTable);
       };
    }
    catch (Exception ex)
    {
        Logger.Error("Error occured while fetching records from SQL server", ex);
    }
