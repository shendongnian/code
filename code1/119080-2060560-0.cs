    using (SqlConnection conn = new SqlConnection("YourConnectionString"))
        {
            using (SqlCommand command = new SqlCommand("usp_YourStoredProcedure", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();
                DataSet ds = new DataSet();
                command.Fill(ds);
            }
        }
