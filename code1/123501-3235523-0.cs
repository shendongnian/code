    public static void StartMouseEnterAnimation(Button button) {
        Storyboard storyboard = new Storyboard();
    
        ScaleTransform scale = new ScaleTransform(1.0, 1.0);
        button.RenderTransformOrigin = new Point(0.5, 0.5);
        button.RenderTransform = scale;
    
        DoubleAnimation growAnimation = new DoubleAnimation();
        growAnimation.Duration = TimeSpan.FromMilliseconds(300);
        growAnimation.From = 1;
        growAnimation.To = 1.8;
        storyboard.Children.Add(growAnimation);
    
        Storyboard.SetTargetProperty(growAnimation, new PropertyPath("RenderTransform.ScaleX"));
        Storyboard.SetTarget(growAnimation, button);
    
        storyboard.Begin();
    }
