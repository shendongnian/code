    //Try set column texts based on data annotation display if available
    var type = ListBindingHelper.GetListItemType(dataGridView1.DataSource);
    var properties = TypeDescriptor.GetProperties(type);
    foreach (DataGridViewColumn column in dataGridView1.Columns)
    {
        var p = properties[column.DataPropertyName];
        if (p != null)
        {
            var display = p.Attributes.OfType<DisplayAttribute>().FirstOrDefault();
            var format = p.Attributes.OfType<DisplayFormatAttribute>().FirstOrDefault();
            column.HeaderText = (display?.GetName()) ?? p.DisplayName;
            column.ToolTipText = (display?.GetDescription()) ?? p.DisplayName;
            column.DefaultCellStyle.Format = (format?.DataFormatString) ?? null;
        }
    }
