    // Always enclose the connection objects in a using statement to free resources
    using(SqlConnection conn = new SqlConnection(.....connectionstringhere....))
    {
        conn.Open();
        string strSQL = "SELECT Name, Account Number FROM customers";
        SqlCommand icmd = new SqlCommand(strSQL, conn);
        SqlDataReader ids = icmd.ExecuteReader();
        // Prepare the MySqlConnection
        using(MySqlConnection conns = new MySqlConnection(....as above....))
        {
             conns.Open();
             // Prepare the command only once outside the inner loop and use parameters
             string strMySQL = @"insert into customer(CusName, CusAcc) 
                                 Values(@name, @acc)";
             MySQLCommand icmds =  New MySQLCommand(strMYSQL, conns)
             icmds.Parameters.Add("@name", MySqlDbType.VarChar);
             icmds.Parameters.Add("@acc", MySqlDbType.VarChar);
             while (ids.Read())
             {
                  // At each loop set the parameters new values and execute the command
                  // Note that I use the values extracted at each loop from the 
                  // SqlDataReader
                  icmds.Parameters["@name"].Value = ids["Name"].ToString();
                  icmds.Parameters["@acc"].Value = ids["AccountNumber"].ToString();
                  icmds.ExecuteNonQuery();
             }
           
        }  // Here the MySqlConnection is closed and disposed
    } // Here the SqlConnection is closed and disposed
