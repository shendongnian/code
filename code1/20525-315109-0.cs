    using (SqlConnection con = new SqlConnection(connectionString))
    {
        con.Open();
        try
        {
            Console.WriteLine("Server is {0}", con.ServerVersion);
            Console.WriteLine("Clr is {0}", Environment.Version);
            for (int i = 0; i < 5; i++)
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "insert into TXTEST values ( " + i + " )";
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Row inserted");
            }
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
        catch
        {
            SqlConnection.ClearPool(con);
            throw;
        }
    }
