    using (SqlConnection cn = new SqlConnection(connectionString))
    {
        using (SqlCommand cm = new SqlCommand(commandString, cn))
        {
            cn.Open();
            cm.ExecuteNonQuery(); // or fill a dataset, etc.
        }
    }
