    void show()
    {
        String query = "select * from student";
        SqlDataAdapter adapter = new SqlDataAdapter(query, con);
        DataTable dataInTable = new DataTable();
        adapter.Fill(dataInTable);
        dataGridView1.Rows.Clear(); // <--- here
        foreach (DataRow item in dataInTable.Rows)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
            dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
            dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
            dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
            dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
        }
    }
