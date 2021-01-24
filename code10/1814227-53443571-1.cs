    string SQLQuery = "INSERT INTO TABLEABC (RText, TDate) VALUES (@RText, @TDate)";
    
    // edit: TDate is a string, convert it to DateTime first
    var date = DateTime.ParseExact(TDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
                    date = date.AddDays(56);
                }
    
                cmd.Parameters.AddWithValue("@TDate", date);
    
                cmd.ExecuteNonQuery();
            }
        }
    }
