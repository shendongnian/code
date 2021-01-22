    var cellInfo = dataGrid.CurrentCell;
    if (cellInfo != null)
    {
        var column = cellInfo.Column as DataGridBoundColumn;
        if (column != null)
        {
            var element = new FrameworkElement() { DataContext = cellInfo.Item };
            BindingOperations.SetBinding(element, FrameworkElement.TagProperty, column.Binding);
            var cellValue = element.Tag;
        }
    }
