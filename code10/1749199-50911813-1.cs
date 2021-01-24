    var list = new List<Product>() {
        new Product(){ Id=1, Name="Product 1", Price= 321.1234},
        new Product(){ Id=2, Name="Product 2", Price= 987.5678},
    };
    this.dataGridView1.DataSource = list;
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
