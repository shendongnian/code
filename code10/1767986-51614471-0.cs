    private void Dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        var dgv = (DataGridView)sender;
        var row = dgv.Rows[e.RowIndex];
        var val = row.Cells[0].Value?.ToString();
        if (val == "OFFER")
            row.DefaultCellStyle.BackColor = Color.OrangeRed;
        else if (val == "BID")
            row.DefaultCellStyle.BackColor = Color.CornflowerBlue;
        else
            row.DefaultCellStyle.BackColor = Color.LightGray;
    }
