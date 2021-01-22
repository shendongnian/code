    private void Form1_Load(object sender, EventArgs e)
    {
        CalendarColumn col = new CalendarColumn();
        this.dataGridView1.Columns.Add(col);
        this.dataGridView1.RowCount = 5;
        foreach (DataGridViewRow row in this.dataGridView1.Rows)
        {
            row.Cells[0].Value = DateTime.Now;
        }
    }
