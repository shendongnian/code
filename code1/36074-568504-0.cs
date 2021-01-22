    private void resultsGrid_DateFormatting(object sender,  System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
         if(resultsGrid.Columns[e.ColumnIndex].Name.Equals("DateOfBirth"))
        {
            if ((string)resultsGrid.CurrentRow.Cells["DateOfBirth"].Value == DateTime.MinValue.ToString())
            {
                 // Set cell value to ""
            }
        }
    }
