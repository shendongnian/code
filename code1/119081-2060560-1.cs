    using (SqlConnection conn = new SqlConnection("YourConnectionString"))
        {
            using (SqlDataAdapter command = new SqlDataAdapter("usp_YourStoredProcedure", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();
                DataSet ds = new DataSet();
                command.Fill(ds);
            }
        }
