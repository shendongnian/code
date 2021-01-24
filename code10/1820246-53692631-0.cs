    var selectedRadioButton = 
            groupKamera.Controls
           .OfType(Of RadioButton)
           .FirstOrDefault(Function(r) r.Checked = True);
    
    sqlDataAdapter1.InsertCommand.Parameters.Add("@n", SqlDbType.VarChar).Value = this.selectedRadioButton.Name;
