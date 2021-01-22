    private System.Collections.Generic.Dictionary<int, bool> checkState;
    private void Form1_Load(object sender, EventArgs e)
    {
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.DataSource = customerOrdersBindingSource;
    
        // The check box column will be virtual.
        dataGridView1.VirtualMode = true;
        dataGridView1.Columns.Insert(0, new DataGridViewCheckBoxColumn());
    
        // Initialize the dictionary that contains the boolean check state.
        checkState = new Dictionary<int, bool>();
    }
    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        // Update the status bar when the cell value changes.
        if (e.ColumnIndex == 0 && e.RowIndex != -1)
        {
            // Get the orderID from the OrderID column.
            int orderID = (int)dataGridView1.Rows[e.RowIndex].Cells["OrderID"].Value;
            checkState[orderID] = (bool)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
    
    }
    
    private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
    {
        // Handle the notification that the value for a cell in the virtual column
        // is needed. Get the value from the dictionary if the key exists.
    
        if (e.ColumnIndex == 0)
        {
            int orderID = (int)dataGridView1.Rows[e.RowIndex].Cells["OrderID"].Value;
            if (checkState.ContainsKey(orderID))
            {
                e.Value = checkState[orderID];
            }
            else
                e.Value = false;
        }
    
    }
    
    private void dataGridView1_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
    {
        // Handle the notification that the value for a cell in the virtual column
        // needs to be pushed back to the dictionary.
    
        if (e.ColumnIndex == 0)
        {
            // Get the orderID from the OrderID column.
            int orderID = (int)dataGridView1.Rows[e.RowIndex].Cells["OrderID"].Value;
    
            // Add or update the checked value to the dictionary depending on if the 
            // key (orderID) already exists.
            if (!checkState.ContainsKey(orderID))
            {
                checkState.Add(orderID, (bool)e.Value);
            }
            else
                checkState[orderID] = (bool)e.Value;
        }
    }
