    private void setNames_Click(object sender, RoutedEventArgs e)
    {
        string userName1 = nameEnter1.Text;
        string userName2 = nameEnter2.Text;
        memoryGridInstance.player1 = userName1;
        memoryGridInstance.player2 = userName2;
        name1.Content = userName1;
        name2.Content = userName2;
        set1.Visibility = Visibility.Collapsed;
        set2.Visibility = Visibility.Collapsed;
    }
