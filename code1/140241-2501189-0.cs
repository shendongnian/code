    using (SqlConnection dataConnection = new SqlConnection(connectionString))
    {
        using (SqlCommand SqlCom = dataConnection.CreateCommand())
        {
            SqlCom.CommandText = "Select * from Login where Username like @Username and Password like @Password";
            SqlCom.Parameters.Add(new SqlParameter("@Username", sUserName)); 
            SqlCom.Parameters.Add(new SqlParameter("@Password", sPassword)); 
    
            dataConnection.Open();
            SqlDataReader myreader; 
            myreader = SqlCom.ExecuteReader(); 
            dataConnection.Close();
        }
    }
