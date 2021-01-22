    // Create a DataGridView
    System.Windows.Forms.DataGridView dgvCombo = new System.Windows.Forms.DataGridView();
    
    // Create a DataGridViewComboBoxColumn
    System.Windows.Forms.DataGridViewComboBoxColumn colCombo = new 
    
    System.Windows.Forms.DataGridViewComboBoxColumn();
    
    // Add the DataGridViewComboBoxColumn to the DataGridView
    dgvCombo.Columns.Add(colCombo);
    
    // Define a data source somewhere, for instance:
    public enum DataEnum
    {
    	One,
    	Two,
    	Three
    }
    
    // Bind the DataGridViewComboBoxColumn to the data source, for instance:
    colCombo.DataSource = Enum.GetNames(typeof(DataEnum));
    
    // Create a DataGridViewRow:
    DataGridViewRow row = new DataGridViewRow();
    
    // Create a DataGridViewComboBoxCell:
    DataGridViewComboBoxCell cellCombo = new DataGridViewComboBoxCell();
    
    // Bind the DataGridViewComboBoxCell to the same data source as the DataGridViewComboBoxColumn:
    cellCombo.DataSource = Enum.GetNames(typeof(DataEnum));
    
    // Set the Value of the DataGridViewComboBoxCell to one of the values in the data source, for instance:
    cellCombo.Value = "Two";
    // (No need to set values for DisplayMember or ValueMember.)
    
    // Add the DataGridViewComboBoxCell to the DataGridViewRow:
    row.Cells.Add(cellCombo);
    
    // Add the DataGridViewRow to the DataGridView:
    dgvCombo.Rows.Add(row);
    
    // To avoid all the annoying error messages, handle the DataError event of the DataGridView:
    dgvCombo.DataError += new DataGridViewDataErrorEventHandler(dgvCombo_DataError);
    
    void dgvCombo_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
    	// (No need to write anything in here)
    }
