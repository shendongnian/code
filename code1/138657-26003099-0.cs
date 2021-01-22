    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        DataGridView grid = sender as DataGridView;
        if (grid.Columns[e.ColumnIndex].HeaderText == "Text ID")
        {
            // Suppose you want to prevent them from leaving a cell when the text
            // in a specific column contains spaces:
            
            // value will hold the new data
            string value = (string)e.FormattedValue;
                 
            if (value.Contains(" "))
            {
                grid.Rows[e.RowIndex].ErrorText = "String IDs cannot contain spaces.";
                // Setting e.Cancel will prevent them from leaving the cell.
                e.Cancel = true;
            }
        }
        else if (grid.Columns[e.ColumnIndex].HeaderText == "Platform")
        {
            // Or, suppose you have another column that can only contain certain values.
            // You could have used a ComboBoxColumn, but it didn't play with paste, or something.
            if (grid.EditingControl != null && (string)e.FormattedValue != "All")
            {
                // Going straight to the EditingControl will allow you to overwrite what
                // the user thought they were going to do.
                // Note: You don't want to e.Cancel here, because it will lock them
                // into the cell. This is just a brute force fix by you.
                string oldvalue = (string)grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                grid.EditingControl.Text = "All"; // or set it to the previous value, if you like.
            }
        }
    }
