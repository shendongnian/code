    private DataGridComboBoxColumn CreateComboValueColumn(List<Elements> elements)
    {
        DataGridComboBoxColumn column = new DataGridComboBoxColumn();
        Style style = new Style(typeof(ComboBox));
        style.Setters.Add(new Setter(ComboBox.ItemsSourceProperty, new Binding("ComboItems")));
        column.DisplayMemberPath = "Text";
        column.SelectedValuePath = "ID";
        column.SelectedValueBinding = new Binding("Value");
        column.ElementStyle = style;
        column.EditingElementStyle = style;
        return column;
    }
