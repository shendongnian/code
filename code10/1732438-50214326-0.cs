    void InsertButton_Click(Object sender, EventArgs e)
    {
        con.Open();
        OleDbCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into customerOrder values('"+txtFname.Text+"','"+txtLname.Text+"')";
        cmd.ExecuteNonQuery();
        con.Close();
        txtFname.Text = "";
        txtLname.Text = "";
        MessageBox.Show("Inserted Successfully!");
        ViewButton_Click(sender, e)
    }
    
    void ViewButton_Click(Object sender, EventArgs e)
    {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from customerOrder";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
    }
