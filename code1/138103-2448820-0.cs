    public static DependencyProperty CurrentFooProperty = DependencyProperty.Register(
        "CurrentFoo",
        typeof(Foo), 
        typeof(FooHandler),
        new PropertyMetadata(OnCurrentFooChanged));
    private static void OnCurrentFooChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var currentFoo = (Foo) e.NewValue;
        // Use
    }
