    private int index;
    
    private void AnimationButton_Click(object sender, RoutedEventArgs e)
    {
        BeginConnectedAnimation((UIElement)sender, ConnectionDestination);
    }
    
    private async void BeginConnectedAnimation(UIElement source, UIElement destination)
    {
        var service = ConnectedAnimationService.GetForCurrentView(this);
        service.PrepareToAnimate($"Test{index}", source);    
       
        var animation = service.GetAnimation($"Test{index}");
        animation?.TryStart(destination);
    
        // use different Key when click。
        index++;
    }
