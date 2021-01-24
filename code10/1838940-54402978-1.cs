    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if ((e.KeyCode != Keys.Enter) || (textBox1.Text.Length == 0))
        {
            return;
        }
        conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Database\book1.mdf;Integrated Security=True;Connect Timeout=30");
        conn.Open();
        SqlDataAdapter adp = new SqlDataAdapter("SELECT productid,ProductName,Description,Stock,UOM,Price from ProductTable where productId='" + textBox1.Text + "'", conn);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        foreach (DataRow item in dt.Rows)
        {
            int i = dataGridView1.Rows.Add();
            DataGridViewRow row = dataGridView1.Rows[i];
            row.Cells[0].Value = item[0].ToString();
            row.Cells[1].Value = item[1].ToString();
            row.Cells[2].Value = item[2].ToString();
            row.Cells[3].Value = item[3].ToString();
            row.Cells[4].Value = item[4].ToString();
            row.Cells[5].Value = item[5].ToString();
        }
    }
