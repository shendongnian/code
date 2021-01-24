    public DropDownButton()
    {
        SetCurrentValue(MenuOptionsProperty, new List<TextBlock>());
    }
    public static readonly DependencyProperty MenuOptionsProperty =
        DependencyProperty.Register(
            nameof(MenuOptions), typeof(List<TextBlock>), typeof(DropDownButton));
    public ObservableCollection<TextBlock> MenuOptions
    {
        get { return (List<TextBlock>)GetValue(MenuOptionsProperty); }
        set { SetValue(MenuOptionsProperty, value); }
    }
