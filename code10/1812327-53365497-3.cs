    private void Next_Btn(object sender, RoutedEventArgs e)
    {
       if (this.NavigationService.CanGoForward)
           NavigationService.GoForward();
        else
            NavigationService.Navigate(new HomeView());
    }
    private void Back_Btn(object sender, RoutedEventArgs e)
    {
        if (this.NavigationService.CanGoBack)
            NavigationService.GoBack();
        else
            NavigationService.Navigate(new HomeView());
    }
