    private void MenuChoice1_Click(object sender, RoutedEventArgs e)
    {
        (DataContext as ScreenToShow)._State = ScreenToShow.MenuState.MenuChoice1;
    }
    
    private void MenuChoice2_Click(object sender, RoutedEventArgs e)
    {
        (DataContext as ScreenToShow)._State = ScreenToShow.MenuState.MenuChoice2;
    }
    
    private void MenuChoice3_Click(object sender, RoutedEventArgs e)
    {
        (DataContext as ScreenToShow)._State = ScreenToShow.MenuState.MenuChoice3;
    }
