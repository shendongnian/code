    // reference the combobox column
    DataGridViewComboBoxColumn cboBoxColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns[0];
    cboBoxColumn.DataSource = Choice.GetChoices();
    cboBoxColumn.DisplayMember = "Name";  // the Name property in Choice class
    cboBoxColumn.ValueMember = "Value";  // ditto for the Value property
