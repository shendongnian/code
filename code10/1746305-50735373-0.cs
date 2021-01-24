    SqlConnectionStringBuilder objSqlConnectionStringBuilder = new SqlConnectionStringBuilder();
    objSqlConnectionStringBuilder.DataSource                 = sMyDatabaseServer;
    objSqlConnectionStringBuilder.IntegratedSecurity         = true;
    objSqlConnectionStringBuilder.InitialCatalog	     = sMyDatabaseName;
    objSqlConnectionStringBuilder.ConnectTimeout	     = 30;
    objSqlConnectionStringBuilder.Pooling		     = false;
    using(SqlConnection objSqlConnection  = new SqlConnection(objSqlConnectionStringBuilder.ConnectionString))
        {
        objSqlConnection.Open();
        using (SqlCommand objSqlCommand = new SqlCommand(sSQLQuery, objSqlConnection))
            {
            objSqlCommand.ExecuteNonQuery();
            }
        }
