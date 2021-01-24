    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (dataGridView1.CurrentCell.ColumnIndex == 1 && e.Control is ComboBox)
        {
            ComboBox comboBox = e.Control as ComboBox;
            comboBox.SelectedIndexChanged -= LastColumnComboSelectionChanged;
            comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
        }
    }
    private void LastColumnComboSelectionChanged(object sender, EventArgs e)
    {
        var currentcell = dataGridView1.CurrentCellAddress;
        var sendingCB = sender as DataGridViewComboBoxEditingControl;
        DataGridViewTextBoxCell cel = (DataGridViewTextBoxCell)dataGridView1.Rows[currentcell.Y].Cells[0];
        //HERE YOU SHOULD DISABLE OR ENABLE TEXTBOX
    }
