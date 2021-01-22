    public static DependencyProperty AProperty = DependencyProperty.Register("A", typeof(double), typeof(ValidateTest), new PropertyMetadata(1.0, null, coerceValue), validateValue);
    public static DependencyProperty BProperty = DependencyProperty.Register("B", typeof(double), typeof(ValidateTest), new PropertyMetaData(bChanged));
    static object coerceValue(DependencyObject d, object value)
    {
        var bVal = (double)d.GetValue(BProperty);
        if ((double)value > bVal)
            return bVal;
        return value;
    }
    static bool validateValue(object value)
    {
        return (double)value > 0;
    }
