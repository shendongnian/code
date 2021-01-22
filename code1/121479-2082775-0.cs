    using (SqlConnection conn = new SqlConnection(connString))
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@RegistrationNumber", SqlDbType.VarChar);
            cmd.Parameters["@RegistrationNumber"].Value = ** your variable here**;
            try
            {
                conn.Open();
                double cost = (double)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
     
