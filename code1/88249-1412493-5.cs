    private void myDataGridView_UserAddedRow
                (object sender, DataGridViewRowEventArgs e)
    {
        e.Row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#CCFF99");
    }
    
    private void myDataGridView_UserDeletedRow
                (object sender, DataGridViewRowEventArgs e)
    {
        e.Row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCC99");
    }
    
    private void myDataGridView_CellValueChanged
                (object sender, DataGridViewCellEventArgs e)
    {
       myDataGridView[e.ColumnIndex, e.RowIndex].DefaultCellStyle.BackColor 
                                              = ColorTranslator.FromHtml("#FFFF99");
    }
