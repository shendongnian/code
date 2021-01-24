    private void ListBox_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        var viewModel = DataContext as YourViewModelType;
        if (viewModel != null && ListBoxFirst.SelectedItem != null)
        {
            viewModel.YourImplementedMethod(ListBoxFirst.SelectedItem);
        }
    }
