    private void datagrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        DataGrid dg = sender as DataGrid;
       if (dg!= null && dg.SelectedItems != null && dg.SelectedItems.Count == 1)
       {
           DataRowView dr = dg.SelectedItem as DataRowView;
           int id = Convert.ToInt32(dr["Id"].ToString());
       }
    }
