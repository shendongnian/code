    public static BindableProperty ButtonHostProperty = BindableProperty.Create(nameof(ButtonHost), typeof(IFloatingActionButtonHost), typeof(FabButton));
    public IFloatingActionButtonHost ButtonHost
    {
        get => (IFloatingActionButtonHost)GetValue(ButtonHostProperty);
        set => SetValue(ButtonHostProperty, value);
    }
