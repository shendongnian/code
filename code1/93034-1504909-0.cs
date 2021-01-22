    using (SqlConnection conn = new SqlConnection(connString))
    {
          SqlCommand cmd = new SqlCommand("SELECT * FROM whatever 
                                           WHERE id = 5", conn);
            try
            {
                conn.Open();
                newID = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
     }
