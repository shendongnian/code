    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var viewModel = DataContext as YourViewModelClass;
        if (viewModel != null)
            viewModel.AddInputCity("new...");
    }
