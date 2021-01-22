    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        Client client = new Client();
        // Set client as the DataContext.
        DataContext = client;
        client.Name = "Michael";
        Thread.Sleep(1000);
        client.Name = "Johnson";
    }
