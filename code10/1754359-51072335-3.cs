        string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users...\Documents\TestDB.accdb";
         
        private void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into table1 values('" + textBox1.Text + "','" + textBox2.Text + "')";
            OleDbCommand cmd= new OleDbCommand(sql);
            using (OleDbConnection con = new OleDbConnection(connString)) {
                cmd.Connection = conn;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("record inserted successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR" + ex.Message);
                }
            }
       }
