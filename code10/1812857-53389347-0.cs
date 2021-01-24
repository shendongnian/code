    private void ShowRowIndex_Btn(object sender, RoutedEventArgs e)
    {
        int[] indices = myDataGrid.SelectedItems.Select(i => 
             myDataGrid.ItemsSource.IndexOf(i)).ToArray();
        if (indices.Any())
        {
           MessageBox.Show(indices[0].ToString());
        }
    }
