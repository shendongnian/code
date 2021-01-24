    private void MyButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBoxResult messageBoxResult = MessageBox.Show("Navigate to page?", "Test", MessageBoxButton.YesNo);
        if (messageBoxResult == MessageBoxResult.Yes)
        {
            System.Windows.Navigation.NavigatedEventHandler handler = null;
            handler = async (ss, ee) =>
            {
                await Task.Delay(1000);
                MessageBox.Show("Success");
                MyFrame.Navigated -= handler;
            };
            MyFrame.Navigated += handler;
            MyFrame.NavigationService.Navigate(new Uri("Test.xaml", UriKind.Relative));
        }
    }
