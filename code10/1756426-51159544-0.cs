    private void dgvStatus_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex != btnDelete.Index || e.RowIndex < 0)
            return;
        if (e.RowIndex % 2 == 0)
            e.CellStyle.BackColor = ColorTranslator.FromHtml("#3E606F");        
        else
            e.CellStyle.BackColor = ColorTranslator.FromHtml("#91AA9D");
    }
