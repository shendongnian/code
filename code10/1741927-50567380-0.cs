    public static double GetSmallFloatIncrement(DependencyObject obj)
    {
        return (double)obj.GetValue(SmallFloatIncrementProperty);
    }
    public static void SetSmallFloatIncrement(DependencyObject obj, double value)
    {
        obj.SetValue(SmallFloatIncrementProperty, value);
    }
    public static readonly DependencyProperty SmallFloatIncrementProperty =
        DependencyProperty.RegisterAttached("SmallFloatIncrement", typeof(double), typeof(TextBoxExtensions),
            new PropertyMetadata(0.0));
