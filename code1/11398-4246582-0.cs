    // get Connection
    System.Data.IDbConnection con = ActiveRecordMediator.GetSessionFactoryHolder()
                                                        .GetSessionFactory(typeof(Autocomplete))
                                                        .ConnectionProvider.GetConnection();
    
    // set Command
    System.Data.IDbCommand cmd = con.CreateCommand();
    cmd.CommandText = "name_of_stored_procedure";
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
    // set Parameter of Stored Procedure
    System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@parameter_name", System.Data.SqlDbType.NVarChar);
    param.Value = "value_of_parameter";
    ((System.Data.SqlClient.SqlParameterCollection)cmd.Parameters).Add(param);
    
    // call Stored Procedure (without getting result)
    cmd.ExecuteNonQuery();
    
    // ... or read results
    System.Data.SqlClient.SqlDataReader r = (System.Data.SqlClientSqlDataReader)cmd.ExecuteReader();
    while(r.Read()) {
        System.Console.WriteLine("result first col: " + r.GetString(0));
    }
