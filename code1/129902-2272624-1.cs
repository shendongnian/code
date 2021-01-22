    public static readonly DependencyProperty FooProperty = DependencyProperty.Register(
        "Foo",
        typeof(string),
        typeof(MyCustomComboBox),
        new FrameworkPropertyMetadata(
            null,
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault);
