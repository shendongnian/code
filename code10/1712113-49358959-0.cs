    private DataGridComboBoxColumn CreateComboValueColumn()
    {
    DataGridComboBoxColumn column = new DataGridComboBoxColumn();
    column.ElementStyle = YourWindowName.FindResource("ComboBoxElementStyle") as Style;
    column.EditingElementStyle = YourWindowName.FindResource("ComboBoxEditingElementStyle") as Style;
    return column;
    }
