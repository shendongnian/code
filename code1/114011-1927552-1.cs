    using (SqlConnection conn = new SqlConnection(connStr))
    using (SqlCommand cmdWrite = new SqlCommand("insert into bar values (@beer)", conn))
    {
        conn.Open();
        SqlParameter beer = new SqlParameter("@beer", SqlDbType.Int);
        cmdWrite.Parameters.Add(beer);
        cmdWrite.Parameters["@beer"].value = stools;
        cmdWrite.ExecuteNonQuery(); 
    }
