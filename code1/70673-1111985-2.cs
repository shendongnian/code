     Microsoft.Practices.EnterpriseLibrary.Data.Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("ConnectionString");
     System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("StoredProcedureName");
     cmd.CommandTimeout = 600;
     db.AddInParameter(cmd, "ParameterName", DbType.String, "Value");
     // Added to handle paramValues array conversion
     foreach (System.Data.SqlClient.SqlParameter param in parameterValues) 
     {
         db.AddInParameter(cmd, param.ParameterName, param.SqlDbType, param.Value);
     }
     return cmd.ExecuteScalar();
