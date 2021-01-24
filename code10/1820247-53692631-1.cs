    var selectedRadioButton = groupKamera.Controls
       .OfType<RadioButton>()
       .FirstOrDefault(t => t.Checked = true);
    
    sqlDataAdapter1.InsertCommand.Parameters.Add("@n", SqlDbType.VarChar).Value = this.selectedRadioButton.ID;
