    public static readonly BindableProperty MaxInputValueProperty = BindableProperty.Create(nameof(MaxInputValue), typeof(int), typeof(ColorTextLabelBehavior), defaultValue: 100);
    public static readonly BindableProperty MinInputValueProperty = BindableProperty.Create(nameof(MinInputValue), typeof(int), typeof(ColorTextLabelBehavior), defaultValue: 0);
    public static readonly BindableProperty InputValueProperty = BindableProperty.Create(nameof(InputValue), typeof(int), typeof(ColorTextLabelBehavior), defaultValue: 100);
    public int MaxInputValue
    {
        get { return (int)GetValue(MaxValue); }
        set { SetValue(MaxValue, value); }
    }
    public int MinInputValue
    {
        get { return (int)GetValue(MinValue); }
        set { SetValue(MinValue, value); }
    }
    public int InputValue
    {
        get { return (int)GetValue(ActualValue); }
        set { SetValue(ActualValue, value); }
    }
