    private void _button_Click(object sender, RoutedEventArgs e)
    {
       _progressBar.Visibility = Visibility.Visible;
    
       new Thread((ThreadStart) delegate
       {
           //do time-consuming work here
    
           //then dispatch back to the UI thread to update the progress bar
           Dispatcher.Invoke((ThreadStart) delegate
           {
               _progressBar.Visibility = Visibility.Hidden;
           });
    
       }).Start();
    }
