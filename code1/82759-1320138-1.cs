    using System.Data;
    using System.Data.SqlClient;
    //...
    SqlConnection dbConn = new 
        SqlConnection("Data Source=localhost;Initial Catalog=MyDB;Integrated Security=SSPI");
    SqlCommand dbComm = new SqlCommand();
    SqlDataReader dbRead;
    
    dbConn.Open();
    dbComm.Connection = dbConn;
    
    dbComm.CommandText = "select name from customers where state = @state";
    dbComm.Parameters.Add("@state", System.Data.SqlDbType.VarChar);
    dbComm.Parameters["@state"].Value = "NY";
    
    dbRead = dbComm.ExecuteReader();
    
    if(dbRead.HasRows)
    {
    	while(dbRead.Read())
    	{
    		Console.WriteLine(dbRead[0].ToString());
    	}
    }
    
    dbRead.Close();
    dbConn.Close();
