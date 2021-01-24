    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MainWindow.Frame.Navigated += Frame_Navigated;
        MainWindow.Frame.NavigationService.GoBack();
    }
    private void Frame_Navigated(object sender, NavigationEventArgs e)
    {
        Frame frame = (Frame)sender;
        frame.Navigated -= Frame_Navigated;
        Page1 p1 = frame.Content as Page1;
        p1.updateTable();
    }
