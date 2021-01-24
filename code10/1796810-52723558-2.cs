    string query = @"
        SELECT EmpID, LAST_DAY(`Date`) AS Month, COUNT(*) As NumEntries
        FROM tblnm 
        GROUP BY EmpID, LAST_DAY(`Date`)
        HAVING COUNT(*) >= 4;";
    using (var con = new MySqlConnection(serverstring))
    using (var cmd = new MySqlCommand(query, con))
    {
        con.Open();
        using (MySqlDataReader rdr = cmd.ExecuteReader())
        {     
            while(rdr.Read())
            {
               triggerEmail(rdr["EmpID"], (int)rdr["NumEntries"]);
            }
        }
    }
