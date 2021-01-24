    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var clickedElement = e.OriginalSource;
        Debug.WriteLine(clickedElement);
    }
