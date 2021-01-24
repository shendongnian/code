    private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.RosyBrown;
        dataGridView1[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.LightSeaGreen;
    }
    private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
    {
        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Empty;
        dataGridView1[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Empty;
    }
