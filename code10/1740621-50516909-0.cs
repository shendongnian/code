    private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        dynamic viewModel = e.NewValue;
        var uri = viewModel.Uri;
        (DataContext as TreeViewModel).Navigate(uri);
    }
