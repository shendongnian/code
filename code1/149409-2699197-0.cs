    public void PopulateLocalData() 
    { 
       using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
       {
           cmd.CommandType = System.Data.CommandType.StoredProcedure; 
           cmd.CommandText = "usp_PopulateServiceSurveyLocal"; 
           DataLayer.DataProvider.ExecSQL(ConnString, cmd);
       }
    } 
