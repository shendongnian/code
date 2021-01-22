    drpTypes.Items.Add(new ListItem("Tipos de Acções", "1"));
    drpTypes.Items.Add(new ListItem("Tipos de Combustível", "2"));
    drpTypes.Items.Add(new ListItem("Tipos de Condutor", "3"));
    
    drpTypesCreateEdit.Items.AddRange(drpTypes.Items);
    
    drpTypes.SelectedValue = "2";
    drpTypesCreateEdit.SelectedValue = "3";
