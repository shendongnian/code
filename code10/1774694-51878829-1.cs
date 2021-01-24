    public static ICommand GetTextUpdateCommandProperty(DependencyObject obj)
    {
        return (ICommand)obj.GetValue(TextUpdateCommandProperty);
    }
    public static void SetTextUpdateCommandProperty(DependencyObject obj, ICommand value)
    {
        obj.SetValue(TextUpdateCommandProperty, value);
    }
