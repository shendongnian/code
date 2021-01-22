     SqlCommand cmd = new SqlCommand("EXECUTE AS USER = 'domain\\user';");
     OSSDBDataContext dc = new OSSDBDataContext();
     cmd.Connection = dc.Connection as SqlConnection;
     cmd.Connection.Open();
     cmd.ExecuteNonQuery();
     //Execute stored procedure code goes here
     SqlCommand cmd2 = new SqlCommand("REVERT;");
     cmd2.Connection = dc.Connection as SqlConnection;
     cmd2.ExecuteNonQuery();
