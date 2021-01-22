    using(SqlConnection _con = new SqlConnection('your connection string here'))
    {
        using(SqlCommand _cmd = new SqlCommand("InsertData", _con)
        {
            _cmd.CommandType = CommandType.StoredProcedure;
            // add parameters as necessary
            _cmd.Parameters.AddWithValue("@Name", "Your Name");
            _cmd.Parameters.AddWithValue("@FromDate", "20100101");
            _cmd.Parameters.AddWithValue("@ToDate", "20100331");
            try
            {
                // open connection, execute stored proc, close connection
                _con.Open();
                _cmd.ExecuteNonQuery();
                _con.Close();
            } 
            catch(SqlException sqlexc)
            {
                // handle SQL exception
            }
        }
    }
