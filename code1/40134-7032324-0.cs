    private void dataGridView1_CellParsing(object sender, 
     DataGridViewCellParsingEventArgs e) {
       if (dataGridView1.CurrentCell.OwningColumn is DataGridViewComboBoxColumn) {
           DataGridViewComboBoxEditingControl editingControl = 
                    (DataGridViewComboBoxEditingControl)dataGridView1.EditingControl;
           e.Value = editingControl.SelectedItem;
           e.ParsingApplied = true;
       }
    }
