    for (int i = 0; i < panel.Children.Count; i++)
    {            
        panel.Children[i].Opacity = 0.0;            
        fadeIn.BeginTime = new TimeSpan(0, 0, 0, 0, 200 * i + 50);            
        panel.Children[i].BeginAnimation(UIElement.OpacityProperty, null);        
        panel.Children[i].BeginAnimation(UIElement.OpacityProperty, fadeIn);        
    }
