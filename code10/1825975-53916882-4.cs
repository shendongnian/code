    public DropDownButton()
    {
        SetCurrentValue(MenuOptionsProperty, new List<TextBlock>());
    }
    public static readonly DependencyProperty MenuOptionsProperty =
        DependencyProperty.Register(
            nameof(MenuOptions), typeof(IEnumerable<TextBlock>), typeof(DropDownButton));
    public IEnumerable<TextBlock> MenuOptions
    {
        get { return (IEnumerable<TextBlock>)GetValue(MenuOptionsProperty); }
        set { SetValue(MenuOptionsProperty, value); }
    }
