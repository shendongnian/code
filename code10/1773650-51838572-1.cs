    foreach (DataRow dr in dsleaveplanner.Tables[0].Rows)
    {
        nextDate = (DateTime)dr["date"];
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mydb;Uid=myid;Pwd=abc123;");
        string cntdate = "SELECT COUNT(date) FROM approved WHERE date = @date";
        string cntdate2 = "SELECT COUNT(date) FROM pending WHERE date = @date";
        MySqlCommand cmd2 = new MySqlCommand(cntdate, conn);
        MySqlCommand cmd3 = new MySqlCommand(cntdate2, conn);
        cmd2.Parameters.AddWithValue("@date", nextDate);
        cmd3.Parameters.AddWithValue("@date", nextDate);
        conn.Open();
        string count = cmd2.ExecuteScalar().ToString();
        string count2 = cmd3.ExecuteScalar().ToString();
        var slot2 = Convert.ToInt32(count);
        Int32 slot3 = 10 - slot2;
        string slot4 = slot3.ToString();
        conn.Close();
    
        samples.Add(new Sample { Date = nextDate, SlotAvailable = slot4, Pending = count2 });
    }
