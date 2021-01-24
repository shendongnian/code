    private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
        foreach ( DataGridViewRow row in dataGridView1.SelectedRows)
           row.DefaultCellStyle.SelectionBackColor = Color.Empty;
        foreach ( DataGridViewCell cell in dataGridView1.SelectedCells)
           cell.Style.SelectionBackColor = Color.Empty;
        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.RosyBrown;
        dataGridView1[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.LightSeaGreen;
    }
