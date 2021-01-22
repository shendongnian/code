    PropertyDescriptor pd = DependencyPropertyDescriptor.FromProperty(
        GridViewColumn.WidthProperty, typeof(GridViewColumn));
    GridView gv = (GridView)myListView.View;
    foreach (GridViewColumn col in gv.Columns) {
        pd.AddValueChanged(col, ColumnWidthChanged);
    }
    ...
    private void ColumnWidthChanged(object sender, EventArgs e) { ... }
