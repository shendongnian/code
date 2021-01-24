    DataGridViewComboBoxColumn CreateComboBoxWithEnums()
    {
        DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
        combo.DataSource = Enum.GetValues(typeof(Title));
        combo.DataPropertyName = "Title";
        combo.Name = "Title";
        return combo;
    }
