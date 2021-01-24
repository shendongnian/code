    private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == /* Acumulable column index */)
        {
            e.CellStyle.BackColor = ColorTranslator.FromHtml("#3498DB");
        }
    }
