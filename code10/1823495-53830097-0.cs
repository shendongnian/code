    private void Tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<Object> e)
    {
        var item = (TreeViewItem) e.NewValue;
        System.Windows.MessageBox.MessageBox.Show(item.Header.ToString());
    }
