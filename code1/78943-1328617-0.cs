    public Form1()
    {
        InitializeComponent();
    }
    private Stopwatch watch = new Stopwatch();
    private void Form1_Load(object sender, EventArgs e)
    {
        // populate dataGridView
        for (int i = 0; i < 10000; i++)
            dataGridView1.Rows.Add("Column", i+1, 10000 - i);
        for (int i = 0; i < 10000; i = i + 2)
            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
    }
    // remove filter
    private void button1_Click(object sender, EventArgs e)
    {
        watch.Reset();
        watch.Start();
        foreach (DataGridViewRow row in dataGridView1.Rows)
            row.Visible = true;
        watch.Stop();
        MessageBox.Show(watch.ElapsedMilliseconds.ToString());
    }
    // add filter (hide all odd rows)
    private void button2_Click(object sender, EventArgs e)
    {
        watch.Reset();
        watch.Start();
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            if (Convert.ToInt32(row.Cells[1].Value) % 2 != 0)
                row.Visible = false;
        }
        watch.Stop();
        MessageBox.Show(watch.ElapsedMilliseconds.ToString());
    }
    // remove filter (improved)
    private void button3_Click(object sender, EventArgs e)
    {
        watch.Reset();
        watch.Start();
        List<DataGridViewRow> rows = new List<DataGridViewRow>();
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            rows.Add(row);
        }
        dataGridView1.Rows.Clear();
        foreach (DataGridViewRow row in rows)
            row.Visible = true;
        dataGridView1.Rows.AddRange(rows.ToArray());
        watch.Stop();
        MessageBox.Show(watch.ElapsedMilliseconds.ToString());
    }
    // add filer (improved)
    private void button4_Click(object sender, EventArgs e)
    {
        watch.Reset();
        watch.Start();
        List<DataGridViewRow> rows = new List<DataGridViewRow>();
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            rows.Add(row);
        }
        dataGridView1.Rows.Clear();
        foreach (DataGridViewRow row in rows)
        {
            if (Convert.ToInt32(row.Cells[1].Value) % 2 != 0)
            {
                row.Visible = false;
            }
        }
        dataGridView1.Rows.AddRange(rows.ToArray());
        watch.Stop();
        MessageBox.Show(watch.ElapsedMilliseconds.ToString());
    }
}
