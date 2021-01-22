    public Numbers GetConversionType() 
    {
        EntityName type = (EntityName)numberComboBox.SelectedItem;
        return type.GetNumber();           
    }
