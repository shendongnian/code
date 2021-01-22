    drpTypes.Items.Add(new ListItem("Tipos de Acções", "1"));
    drpTypes.Items.Add(new ListItem("Tipos de Combustível", "2"));
    drpTypes.Items.Add(new ListItem("Tipos de Condutor", "3"));
            
    foreach(ListItem li in drpTypes.Items)
    {
        drpTypesCreateEdit.Items.Add(li);
    }
