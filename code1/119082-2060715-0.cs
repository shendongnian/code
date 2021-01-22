    using (SqlConnection conn = new SqlConnection("YourConnectionString"))
        {
            using (SqlCommand command = new SqlCommand("exec sp_msforeachtable 'select * FROM ?'", conn))
            {
                conn.Open();
    
                DataSet ds = new DataSet();
                command.Fill(ds);
            }
        }
    
            
