    private void CellBox_TextChanged(object sender, EventArgs e)
    {
        ((TextBox)sender).TextChanged -= CellBox_TextChanged;
        ((TextBox)dataGridView1.EditingControl).AutoCompleteMode = AutoCompleteMode.None;
        ((TextBox)dataGridView1.EditingControl).AutoCompleteCustomSource = null;                
        aCSC.Clear();
        foreach (string value in Autocompletevalues())
        {
            aCSC.Add(value);
        }
        ((TextBox)dataGridView1.EditingControl).AutoCompleteCustomSource = aCSC;
        ((TextBox)dataGridView1.EditingControl).AutoCompleteMode = AutoCompleteMode.Suggest;
        ((TextBox)sender).TextChanged += CellBox_TextChanged;
    }
