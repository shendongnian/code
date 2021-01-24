    void SetHarwareStyle(Popup popup)
    {
        var rightToLeftAnimation = new DoubleAnimation()
        {
            From = 0,
            To = 100,
            Duration = TimeSpan.FromMilliseconds(300),
            AccelerationRatio = 0.1
        };
        Storyboard.SetTargetProperty(rightToLeftAnimation, new PropertyPath(WidthProperty));
        var storyboard = new Storyboard();
        storyboard.Children.Add(rightToLeftAnimation);
    
        var beginStoryboard = new BeginStoryboard();
        beginStoryboard.Storyboard = storyboard;
    
        var trigger = new Trigger { Property = Popup.IsOpenProperty, Value = true };
        trigger.EnterActions.Add(beginStoryboard);
    
        var style= new Style();
        style.TargetType = typeof(Popup);
        style.Triggers.Add(trigger);
        popup.Style = style;
    }
