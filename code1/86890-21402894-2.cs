    dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
	
	private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (dataGridView1.CurrentCell.ColumnIndex == 0 && e.Control is ComboBox)
        {
            ComboBox comboBox = e.Control as ComboBox;
            comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
        }
    }
	private void LastColumnComboSelectionChanged(object sender, EventArgs e)
	{
		var sendingCB = sender as DataGridViewComboBoxEditingControl;
		object value = sendingCB.SelectedValue;
		if (value != null)
		{
			int intValue = (int)sendingCB.SelectedValue;
			//do something with value
		}
	}
