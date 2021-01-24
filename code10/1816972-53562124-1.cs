    int id=1;
    string orgnr = "123123";
    string companyName = "Test,company";
    
    string connectionString = "Data Source= oraDB;User Id=;Password=;";
    OracleConnection connection = new OracleConnection(connectionString);
    conn.Open();
    OracleCommand cmd = new OracleCommand();
    cmd.Connection = connection;
   
    cmd.CommandText = "INSERT INTO VENDORS(ID, ORGNR, COMPANYNAME) VALUES (:1, :2, :3)";
    
    cmd.Parameters.Add(new OracleParameter("1",
                                           OracleDbType.Int32,
                                           id,
                                           ParameterDirection.Input));
    
    cmd.Parameters.Add(new OracleParameter("2",
                                           OracleDbType.Varchar2,
                                           orgnr,
                                           ParameterDirection.Input));
    
    cmd.Parameters.Add(new OracleParameter("3",
                                           OracleDbType.Varchar2,
                                           companyName,
                                           ParameterDirection.Input));
    
    int rowsUpdated = cmd.ExecuteNonQuery();
    connection.Dispose();
