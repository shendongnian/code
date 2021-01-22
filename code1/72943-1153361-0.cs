    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(int), typeof(OwnerClass),
            new FrameworkPropertyMetadata(0, null, new CoerceValueCallback(CoerceValue)));
    public int Value
    {
        get { return (int)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }
    private static object CoerceValue(DependencyObject d, object value)
    {
        return (int) value + 1;
    }
