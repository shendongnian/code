    private void RectangleMouseEnter(object sender, MouseEventArgs e)
    {
        var element = (FrameworkElement)sender;
        var animation = new DoubleAnimation(150, TimeSpan.FromSeconds(1));
        element.BeginAnimation(FrameworkElement.WidthProperty, animation);
    }
    private void RectangleMouseLeave(object sender, MouseEventArgs e)
    {
        var element = (FrameworkElement)sender;
        var duration = (element.ActualWidth - 50) / 100;
        var animation = new DoubleAnimation(50, TimeSpan.FromSeconds(duration));
        element.BeginAnimation(FrameworkElement.WidthProperty, animation);
    }
