    using (SqlConnection conn = new SqlConnection(connStr))
    {
        SqlCommand com = new SqlCommand(conn);
        com.CommandType = CommandType.Text;
        com.CommandText = 
            "DELETE FROM tblSTUFF WHERE ITEM_COUNT > @ITEM_COUNT";
        int itemCount = 5;
        com.Parameters.AddWithValue("@ITEM_COUNT", itemCount);
        com.Prepare();
        com.ExecuteNonQuery();
    }
