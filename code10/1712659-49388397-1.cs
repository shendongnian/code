    private void DATAGRID_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        DataGridViewButtonColumn button_column= sender as DataGridViewButtonColumn; 
        //// If this is a new header row or row, do nothing
        if (e.RowIndex < 0 || e.RowIndex == this.DATAGRID.NewRowIndex)
            return;
        
        string status = DATAGRID.Rows[e.RowIndex].Cells["Status"].Value.ToString();
        if (status.Equals("ON")  
            button_column.Text = "OFF"; 
        else 
            button_column.Text = "ON";
    }
