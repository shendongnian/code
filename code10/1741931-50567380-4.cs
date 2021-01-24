    public static bool GetSmallFloatIncrementOn(DependencyObject obj)
    {
        return (bool)obj.GetValue(SmallFloatIncrementOnProperty);
    }
    public static void SetSmallFloatIncrementOn(DependencyObject obj, bool value)
    {
        obj.SetValue(SmallFloatIncrementOnProperty, value);
    }
    public static readonly DependencyProperty SmallFloatIncrementOnProperty =
        DependencyProperty.RegisterAttached("SmallFloatIncrementOn", typeof(bool), typeof(TextBoxExtensions),
            new PropertyMetadata(false, OnSmallFloatIncrementOn));
    static void OnSmallFloatIncrementOn(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var textBox = (TextBox)d;
        void OnKeyDown(object sender, KeyEventArgs keyArgs)
        {
            if (keyArgs.Key == Key.Up)
                IncrementOrDecrementValue(textBox, .01);
            else if (keyArgs.Key == Key.Down)
                IncrementOrDecrementValue(textBox, -.01);
        }
        if ((bool)e.NewValue)
            textBox.PreviewKeyDown += OnKeyDown;
        else
            textBox.PreviewKeyDown -= OnKeyDown;
    }
