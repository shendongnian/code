    private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string strProvider = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = F:\product.accdb";
            string strSql = "Select * from product where productname like '" + textBox1.Text + "*';" ;
            OleDbConnection con = new OleDbConnection(strProvider);
            OleDbCommand cmd = new OleDbCommand(strSql, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable products = new DataTable();
            da.Fill(products);
            dataGridView1.DataSource = products;
            con.Close();
        }
