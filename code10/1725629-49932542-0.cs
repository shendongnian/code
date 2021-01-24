    protected void Button2_Click(object sender, EventArgs e)
    {
        using (var con = new SqlConnection("[DB connection string]"))
        {
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "insertDetails";
                cmd.CommandType = CommandType.StoredProcedure;
    
                // create all parameters outside the loop
                // no need to use `cmd.Parameters.Clear()` here
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@name", SqlDbType.VarChar);
                cmd.Parameters.Add("@email", SqlDbType.VarChar);
                cmd.Parameters.Add("@contact", SqlDbType.VarChar);
                cmd.Parameters.Add("@Addres", SqlDbType.VarChar);
    
                con.Open();
    
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    // assign parameter values inside the loop and execute the query
                    cmd.Parameters["@id"].Value = GridView1.Rows[i].Cells[2].Text);
                    cmd.Parameters["@name"].Value = GridView1.Rows[i].Cells[3].Text);
                    cmd.Parameters["@email"].Value = GridView1.Rows[i].Cells[4].Text);
                    cmd.Parameters["@contact"].Value = GridView1.Rows[i].Cells[5].Text);
                    cmd.Parameters["@Addres"].Value = GridView1.Rows[i].Cells[6].Text);
    
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
