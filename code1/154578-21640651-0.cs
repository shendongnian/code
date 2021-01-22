    private void MenuItemExit_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
    private void Window_Closing(object sender, CancelEventArgs e)
    {
        var response = MessageBox.Show("Do you really want to exit?", "Exiting...",
                                       MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
        if (response == MessageBoxResult.No)
        {
            e.Cancel = true;
        }
    }
    private void Shutdown()
    {
        Application.Current.Shutdown();
    }
