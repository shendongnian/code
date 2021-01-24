    const int K = 10;
    private void Form1_Load(object sender, EventArgs e)
    {
        var dt = new DataTable();
        dt.Columns.Add("C1", typeof(int));
        dt.Columns.Add("C2", typeof(int), $"C1 * {K}");
        dt.Rows.Add(1);
        dt.Rows.Add(2);
        dt.Rows.Add(3);
        dataGridView1.DataSource = dt;
    }
