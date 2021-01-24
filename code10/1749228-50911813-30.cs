    var type = ListBindingHelper.GetListItemType(dataGridView1.DataSource);
    var properties = TypeDescriptor.GetProperties(type);
    foreach (DataGridViewColumn column in dataGridView1.Columns)
    {
        var p = properties[column.DataPropertyName];
        if (p != null)
        {
            var format = (DisplayFormatAttribute)p.Attributes[typeof(DisplayFormatAttribute)];
            column.ToolTipText = p.Description;
            column.DefaultCellStyle.Format = format == null ? null : format.Format;
        }
    }
