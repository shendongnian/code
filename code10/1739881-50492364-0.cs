    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.F1)
        {
            var window = sender as Window;
            var point = Mouse.GetPosition(window);
            Helpers.ExecuteHelpUnderPoint(window, point);
        }
    }
