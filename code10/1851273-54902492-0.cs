    private void MenuFlyout_Opened(object sender, object e)
    {         
        MenuFlyout f = sender as MenuFlyout;
        Style s = new Windows.UI.Xaml.Style { TargetType = typeof(MenuFlyoutPresenter) };
        s.Setters.Add(new Setter(MinHeightProperty, "200"));        
        s.Setters.Add(new Setter(MinWidthProperty, "200"));
        f.MenuFlyoutPresenterStyle = s;
    }
