    #region render
    scroll = new ScrollView
    {
        Content = layout
    };
    AbsoluteLayout.SetLayoutBounds(scroll, new Rectangle(0, 0, 1, 1));
    AbsoluteLayout.SetLayoutFlags(scroll, AbsoluteLayoutFlags.All);
    
    AbsoluteLayout screenMask = new AbsoluteLayout { BackgroundColor = Color.FromHex("#22000000") };
    screenMask.BindingContext = this;
    screenMask.SetBinding(IsVisibleProperty, "IsBusy", BindingMode.OneWay);
    AbsoluteLayout.SetLayoutBounds(screenMask, new Rectangle(0.5, 0.5, 1, 1));
    AbsoluteLayout.SetLayoutFlags(screenMask, AbsoluteLayoutFlags.All);
    
    ActivityIndicator indicator = new ActivityIndicator { Color = Color.Black };
    indicator.BindingContext = this;
    indicator.SetBinding(IsVisibleProperty, "IsBusy",BindingMode.OneWay);
    indicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");
    AbsoluteLayout.SetLayoutBounds(indicator, new Rectangle(0.5, 0.5, 0.1, 0.1));
    AbsoluteLayout.SetLayoutFlags(indicator, AbsoluteLayoutFlags.All);
    
    Content = new AbsoluteLayout
    {
        Children = { scroll, screenMask, indicator }
    };
    #endregion
