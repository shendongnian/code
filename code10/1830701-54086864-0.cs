     public int InputValue
    {
        get { return (int)GetValue(ActualValue); }
        set { SetValue(ActualValue, value); }
    }
    public static readonly BindableProperty ActualValue = BindableProperty.Create("ActualValue", typeof(int), typeof(ColorTextLabelBehavior), defaultValue: 100);
