    // Within AccordionView.xaml.cs
    public static BindableProperty DateProperty = BindableProperty.Create(nameof(Date), typeof(DateTime), typeof(AccordionView), default(DateTime));
    public DateTime Date
    {
        get => (DateTime)GetValue(DateProperty);
        set => SetValue(DateProperty, value);
    }
