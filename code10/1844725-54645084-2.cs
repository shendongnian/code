    try
        {
            SqlCommand cmd = null;
            SqlConnection con = null; Ranks rank = new Ranks();
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "Select * from Records where Name like @Name order by Pno";
            cmd.Parameters.AddWithValue("@Name", "%" + FilterByNameTextbox.Text.Trim() + "%");
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter1.Fill(dt);
    
            dataGridView1.DataSource = dt;
            //add folowing
            if (CachedRows.Any())
            {
                dataGridView1.Rows.AddRange(CachedRows.ToArray());
                CachedRows.Clear();
            }
            Make_fields_Colorful();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
