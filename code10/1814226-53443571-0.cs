    string SQLQuery = "INSERT INTO TABLEABC (RText, TDate) VALUES (@RText, @TDate)";
    
    using (var con = new SqlConnection(connectionString))
    {
        con.Open();
        using (var cmd = new SqlCommand(SQLQuery, con))
        {
            for (var i = 0; i < 20; i++)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@RText", Rtext);
    
                // add for next iterations
                if (i > 0)
                {
                    TDate = TDate.AddDays(56);
                }
    
                cmd.Parameters.AddWithValue("@TDate", TDate);
    
                cmd.ExecuteNonQuery();
            }
        }
    }
