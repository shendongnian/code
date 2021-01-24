    loginControl.LoggedIn += (s, e) => {
        Company_StackPanel.Visibility = Visibility.Visible;
        Event_StackPanel.Visibility = Visibility.Visible;
        Promo_StackPanel.Visibility = Visibility.Visible;
    };
