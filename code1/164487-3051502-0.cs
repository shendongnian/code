    private void Form1_Load(object sender, EventArgs e)
    {
        dataGridView1.RowCount = 8;
        dataGridView1.ColumnCount = 10;
    }
    private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
    {
        var bgColor = ((0 == e.ColumnIndex % 2) && (0 == e.RowIndex % 2))
            ? Color.Red
            : Color.White;
        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = bgColor;
    }
