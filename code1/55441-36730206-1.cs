    string s = null; 
    
    //ExecuteCommand("insert into T(C1) values({0})", s); //Exception
    
    SqlCommand cmd= new SqlCommand(){
    	CommandText = "insert into T(C1) values(@P0)",
    	Connection = new SqlConnection(this.Connection.ConnectionString),
    };
    //cmd.Parameters.AddWithValue("@P0", s); //SqlException
    cmd.Parameters.AddWithValue("@P0", (Object)s??DBNull.Value);
    cmd.Connection.Open();
    cmd.ExecuteNonQuery();
    cmd.Connection.Close();
    
    Ts.OrderByDescending(t=>t.ID).Take(1).Dump();
