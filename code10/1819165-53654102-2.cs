    private async void btn1_Tapped(object sender, TappedRoutedEventArgs e)
    {
        foreach(var el in elements)
        {            
            AnimateOpacity(el.Opacity - 1);
            await Task.Delay(250); 
           //Wait for StoryBoard to complete before moving on to next element
        }
    }
    //TODO Add this to a class
    public void AnimateOpacity(double to, double miliseconds = 250)
    {
        var storyboard = new Storyboard();
        var doubleAnimation = new DoubleAnimation();
        doubleAnimation.Duration = TimeSpan.FromMilliseconds(miliseconds);
        doubleAnimation.EnableDependentAnimation = true;
        doubleAnimation.To = to;
        Storyboard.SetTargetProperty(doubleAnimation, "Opacity");
        Storyboard.SetTarget(doubleAnimation, el);
        storyboard.Children.Add(doubleAnimation);
        storyboard.Begin();
    }
