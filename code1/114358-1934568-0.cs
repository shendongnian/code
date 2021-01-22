    public IEnumerable<Microsoft.Windows.Controls.DataGridRow> GetDataGridRows(Microsoft.Windows.Controls.DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as Microsoft.Windows.Controls.DataGridRow;
                if (null != row) yield return row;
            }
        }
