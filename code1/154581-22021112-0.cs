    private void _MenuExit_Click(object sender, RoutedEventArgs e)
    {
       System.Windows.Application.Current.MainWindow.Close();
    }
    
    //Override the onClose method in the Application Main window
    
    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
        MessageBoxResult result =   MessageBox.Show("Do you really want to close", "",
                                              MessageBoxButton.OKCancel);
        if (result == MessageBoxResult.Cancel)
        {
           e.Cancel = true;
        }
        base.OnClosing(e);
    }
