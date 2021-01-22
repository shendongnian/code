    using (SqlConnection conn = new SqlConnection(
           ConfigurationManager.ConnectionStrings["Name"].ConnectionString))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand("Stored Procedure Name", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter myAdapter = new SqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    myAdapter.Fill(dt);
                }
            }
        }
    }
    System.Text.StringBuilder strResult = new System.Text.StringBuilder("");
    string createtext = (Server.MapPath("./Feeds/") + "feed.txt");
    using (StreamWriter w = File.CreateText(createtext))
    {
        // Do something with w
        w.Flush();
    }
