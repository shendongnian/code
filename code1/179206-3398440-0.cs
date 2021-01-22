    DataTable returnData = null;
    try
    {
        using(SqlConnection connSQL = new SqlConnection(sqlConnection))
        using(SqlCommand sqlCmd = new SqlCommand("STORED_PROC_X", connSQL))
        {
           sqlCmd.CommandType = CommandType.StoredProcedure;
           sqlCmd.CommandTimeout = 1200;
   
           // those two parameters should really be SqlDbType.DateTime!!
           sqlCmd.Parameters.Add("@StartDate", SqlDbType.NVarChar, 25).Value = "07/01/2010";
           sqlCmd.Parameters.Add("@EndDate", SqlDbType.NVarChar, 25).Value = "07/31/2010";
    
           sqlCmd.Parameters.Add("@AuditType", SqlDbType.Int).Value = "0";
    
           sqlCmd.Parameters.Add("@SortBy", SqlDbType.NVarChar, 50).Value = "";
           // those two parameters should really be SqlDbType.Bit !!
           sqlCmd.Parameters.Add("@IsClaimDepartment", SqlDbType.NVarChar, 50).Value = "true";
           sqlCmd.Parameters.Add("@IdsList", SqlDbType.NVarChar, 25).Value = "";
           sqlCmd.Parameters.Add("@ReportType", SqlDbType.NVarChar, 25).Value = "Top 20";
           SqlDataAdapter sqlDataAdpater = new SqlDataAdapter(sqlCmd);
           returnData = new DataTable();
           sqlDataAdpater.Fill(returnData);
       }
       return returnData;
    }
    catch (Exception ex)
    {
       LogErrorMessages("ExecuteStoredProcedure", ex.Message);
       throw;
    }
