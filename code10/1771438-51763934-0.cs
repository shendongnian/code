    private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        var query = "your parameter"; // you need to specify the query parameter by the different situation
        switch (query)
        {
            case null: pivotPage.SelectedIndex = 0; break;
            case "MainPage": pivotPage.SelectedIndex = 0; break;
            case "Page1": pivotPage.SelectedIndex = 1; break;
            default: pivotPage.SelectedIndex = 0; break;
         }
    }
