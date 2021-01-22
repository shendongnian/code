           private IEnumerable<DataGridRow> GetDataGridRowsForButtons(DataGrid grid)
    { //IQueryable 
        var itemsSource = grid.ItemsSource as IEnumerable;
        if (null == itemsSource) yield return null;
        foreach (var item in itemsSource)
        {
            var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
            if (null != row & row.IsSelected) yield return row;
        }
    }
    void Button_Click_dgvs(object sender, RoutedEventArgs e)
    {
        for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
            if (vis is DataGridRow)
            {
               // var row = (DataGrid)vis;
                var rows = GetDataGridRowsForButtons(dgv_Students);
                string id;
                foreach (DataGridRow dr in rows)
                {
                    id = (dr.Item as tbl_student).Identification_code;
                    MessageBox.Show(id);
                     break;
                }
                break;
            }
    }
