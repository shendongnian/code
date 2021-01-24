    private void dgvLogHeader_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        foreach (DataGridViewColumn col in dgvLogHeader.Columns)
        {
            if (col.DefaultCellStyle.BackColor != Color.Empty)
                col.DefaultCellStyle.BackColor = Color.Empty;
        }
        dgvLogHeader.Columns[e.ColumnIndex].DefaultCellStyle.BackColor = Color.Gainsboro;
    }
