    private void Tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<Object> e)
    {
        var item = (DataRowView) e.NewValue;
        System.Windows.MessageBox.MessageBox.Show(item["Id"].ToString());
    }
