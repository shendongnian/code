    bool isAnySelected=false;
    
    private void cmbpastseason_SelectedIndexChanged(object sender, EventArgs e)
    {
        validateComboBox();
    }
    
    private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        validateComboBox();
    }
    
    private void comboBoxDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        validateComboBox();
    }
    
    private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        validateComboBox();
    }
    
    private void validateComboBox()
    {
        if(!string.IsNullOrWhiteSpace(cmbpastseason.Text) || 
            !string.IsNullOrWhiteSpace(comboBoxCategory.Text) ||
            !string.IsNullOrWhiteSpace(comboBoxDept.Text) ||
            !string.IsNullOrWhiteSpace(comboBoxDivision.Text))
            {
                isAnySelected = true;
            }
        else
    	{
    		isAnySelected = false;
    		MessageBox.Show("Nothing Selected");
    	}
    }
