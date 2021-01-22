    private void MyDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
    
            if (e.RowIndex == rowIndexToHighlight)
            {
                e.CellStyle.BackColor = Color.Green;
            }
    
        }
   
