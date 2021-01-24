    private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex < 0 || e.RowIndex < 0 ||
                dataGridView1.Columns[e.ColumnIndex].Name != "CategoryIdColumn")
            return;
        if (dataGridView1[e.ColumnIndex, e.RowIndex].Value == DBNull.Value)
        {
            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Italic);
            e.CellStyle.ForeColor = SystemColors.GrayText;
        }
        else
        {
            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Regular);
            e.CellStyle.ForeColor = SystemColors.ControlText;
        }
    }
