    //Make sure this is part of your class and not local to a method
    private string _comboVal;
    
    //Set your private field inside the SelectedValueChanged event of your combo box
    private void ComboEmployee_SelectedValueChanged(object sender, EventArgs e)
    {
         var employeeComboBox = sender as ComboBox;
         _comboVal = employeeComboBox.Text
    }
    
    //Finally Pass private field value to method SaveTechniciansToNotify
     private void btnClose_Click(object sender, EventArgs e)
     {
                //pass in your private field value
                SaveTechniciansToNotify(_comboVal);
                this.Close();
     }
