    using(var sqlConnection = new SqlConnection(objUtilityDAL.ConnectionString))
    {
        using (SqlCommand cmd = con.CreateCommand())
        {
            // the rest of your code - just replace con with sqlConnection
        }
    }
