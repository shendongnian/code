    public static double GetScrollSpeed(DependencyObject obj)
    {
        return (double)obj.GetValue(ScrollSpeedProperty);
    }
    public static void SetScrollSpeed(DependencyObject obj, double value)
    {
        obj.SetValue(ScrollSpeedProperty, value);
    }
    public static readonly DependencyProperty ScrollSpeedProperty =
        DependencyProperty.RegisterAttached(
        "ScrollSpeed",
        typeof(double),
        typeof(ScrollHelper),
        new FrameworkPropertyMetadata(
            1.0,
            FrameworkPropertyMetadataOptions.Inherits & FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            new PropertyChangedCallback(OnScrollSpeedChanged)));
    private static void OnScrollSpeedChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
    }
    
