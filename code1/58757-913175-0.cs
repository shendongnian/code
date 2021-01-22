    public static readonly DependencyProperty BackProp =
        DependencyProperty.Register(
            "BackTest",
            typeof(ImageSource),
            typeof(StateImageButton),
            new FrameworkPropertyMetadata(OnBackChanged));
    private static void OnBackChanged(
        DependencyObject d, 
        DependencyPropertyChangedEventArgs e)
    {
        var target = (BackTest)d; // Put a breakpoint here
    }
