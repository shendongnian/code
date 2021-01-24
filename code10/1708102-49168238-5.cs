    bool isAnySelected=false;
    public Form1()
    {
    	cmbpastseason.SelectedIndexChanged += CommonHandler;
    	comboBoxCategory.SelectedIndexChanged += CommonHandler;
    	comboBoxDept.SelectedIndexChanged += CommonHandler;
    	comboBoxDivision.SelectedIndexChanged += CommonHandler;
    }
    
    private void CommonHandler(object sender, EventArgs e)
    {
    	validateComboBox();
    }
    
    private void validateComboBox()
    {
        if(!string.IsNullOrWhiteSpace(comboBoxDept.Text) || 
    		!string.IsNullOrWhiteSpace(comboBoxCategory.Text) ||
    		!string.IsNullOrWhiteSpace(comboBoxDept.Text) ||
    		!string.IsNullOrWhiteSpace(comboBoxDivision.Text))
    		{
    			isAnySelected = true;
    		}
    	else
    		isAnySelected = false;
    }
