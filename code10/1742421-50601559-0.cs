    public static readonly BindableProperty AnchorProperty = BindableProperty.Create<CustomWebView, float>(p => p.Anchor, default(float));
    public float Anchor
    {
        get { return (float)GetValue(AnchorProperty); }
        set { SetValue(AnchorProperty, value); }
    }
