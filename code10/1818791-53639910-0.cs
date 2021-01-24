    try
    {
        Console.WriteLine("Connecting to MySQL...");
        conn.Open();
        string sql = "INSERT INTO pull_requests (repoID, branchID, fileID, prStatus, prComments) VALUES (@rID, @bID, @fID, @prS, @prC);";
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@rID", RI);
        cmd.Parameters.AddWithValue("@bID", BI);
        cmd.Parameters.AddWithValue("@fID", FI);
        cmd.Parameters.AddWithValue("@prS", 0);
        cmd.Parameters.AddWithValue("@prC", comment);
        cmd.ExecuteNonQuery();
        long lastId = cmd.LastInsertedId;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
    conn.Close();
