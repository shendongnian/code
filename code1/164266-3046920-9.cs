    private void ChangeText(object sender, RoutedEventArgs e)
    {
        DemoModel model = (sender as Button).DataContext as DemoModel;
        model.DynamicText = (new Random().Next(0, 100).ToString());
    }
