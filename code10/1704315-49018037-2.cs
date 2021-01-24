    private void SelectUser_Checked(object sender, RoutedEventArgs e)
    {
        var binding = (sender as CheckBox).GetBindingExpression(CheckBox.IsCheckedProperty);
        binding.UpdateSource(); // Triggers PropertyChanged Notification
        (DataContext as MyViewModel).PerformMagic();    
    }
