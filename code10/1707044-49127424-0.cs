    private void DisableAndExecute(Action action)
    {
        this.IsEnabled = false;
        action();
        this.IsEnabled = true;
    }
    private void button_Click(object sender, RoutedEventArgs e)
    {
        DisableAndExecute(() =>
        {
            Some code...();
        });
    }
