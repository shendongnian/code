    public void myDataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
    {
        // Identifiers used are:
        var myTableAdapter = new databaseTableAdapters.myTableTableAdapter();
        var myDataTable = myTableAdapter.GetData();
        int rowIndex = myDataGridView.CurrentcellAddress.Y;
        var comboBoxCell = (DataGridViewComboBoxCell)myDataGridView.Rows[rowIndex].Cells[0];
        string itemToAdd;
        
        // Load in the data from the data table
        foreach (System.Data.DataRow row in myDataTable.Rows) 
        {
            // Get the current item to be added
            itemToAdd = row[0].ToString();
            // Make sure there are no duplicates
            if (!comboBoxCell.Items.Contains(itemToAdd)) 
            {
                comboBoxCell.Items.Add(itemToAdd)
            }
        }
        // Send the focus to the next combo box (removes need for a double click)
        myDataGridView.CurrentCell = myDataGridView.Rows[rowIndex + 1].Cells[0]; // <--- HERE
    }
