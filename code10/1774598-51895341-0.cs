    public static readonly BindableProperty ParentWidthProperty = BindableProperty.Create("ParentWidth",
        typeof(double),
        typeof(WrapLayout),
        0.00,
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            ((RepeatableWrapLayout)bindable).SetNewWidth();
        });
    
    public double ParentWidth
    {
        set { SetValue(ParentWidthProperty, value); }
        get { return (double)GetValue(ParentWidthProperty); }
    }
