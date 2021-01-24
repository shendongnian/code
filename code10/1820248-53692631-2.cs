    var selectedRadioButton = groupKamera.Controls
       .OfType<RadioButton>()
       .FirstOrDefault(t => t.Checked);
    
    sqlDataAdapter1.InsertCommand.Parameters.Add("@n", SqlDbType.VarChar).Value = this.selectedRadioButton.ID;
