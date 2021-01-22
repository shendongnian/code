    protected void btn_insert_Click(object sender, EventArgs e)
    {
        string connStr = "your connection string";
        SqlCommand cmd;
        using (SqlConnection con = new SqlConnection(connStr))
        {
            con.Open();
            foreach (GridViewRow g1 in GridView1.Rows)
            {
                try
                {
                    cmd = new SqlCommand("command text", con);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    //Ignore the relevant Sql exception for violating a sql unique index
                }
            }
        }
    }
