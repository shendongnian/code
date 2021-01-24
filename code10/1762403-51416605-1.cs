    private void HistoryButton_Click(object sender, RoutedEventArgs e)
    {
        foreach (Device foo in ConfigurationParameterCollection)
        {
            Console.WriteLine("Value for {0}: {1}", foo.Name, foo.OriginalValue);
            foo.Commit();
        }
    }
