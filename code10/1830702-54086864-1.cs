    public static readonly BindableProperty ActualValue = BindableProperty.Create(nameof(InputValue), typeof(int), typeof(ColorTextLabelBehavior), defaultValue: 100);
    public int InputValue
    {
        get { return (int)GetValue(ActualValue); }
        set { SetValue(ActualValue, value); }
    }
