    // Any control that causes the Window.Closing even to trigger.
    private void MenuItemExit_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
    // Method to handle the Window.Closing event.
    private void Window_Closing(object sender, CancelEventArgs e)
    {
        var response = MessageBox.Show("Do you really want to exit?", "Exiting...",
                                       MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
        if (response == MessageBoxResult.No)
        {
            e.Cancel = true;
        }
        else
        {
            Application.Current.Shutdown();
        }
    }
