    public static readonly DependencyProperty IsSpinningProperty = 
        DependencyProperty.Register(
        "IsSpinning", typeof(Boolean),
        typeof(MyCode)
        );
    public bool IsSpinning
    {
        get { return (bool)GetValue(IsSpinningProperty); }
        set { SetValue(IsSpinningProperty, value); }
    }
