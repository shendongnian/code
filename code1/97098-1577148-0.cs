    using (SqlConnection con = new SqlConnection ("Connection String Here"))
    {
        using (SqlCommand cmd = con.CreateCommand())
        {
            cmd.CommandText = "sp_helptext @procName";
            cmd.CommandType = CommandType.Text;
      
            cmd.Parameters.AddWithValue("procName", "Name Of Stored Proc Here");
    
            con.Open(); 
     
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    /* 
                        You will get the CREATE PROC text here
                        Do what you need to with it
                    */
                }
            }
        }
    }
        
