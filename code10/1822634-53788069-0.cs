    public IEnumerable TbMenuItems
    {
        get { return (IEnumerable)GetValue(TbMenuItemsProperty); }
        set { SetValue(TbMenuItemsProperty, value); }
    }
    public static readonly DependencyProperty TbMenuItemsProperty = DependencyProperty.Register(
        nameof(TbMenuItems), typeof(IEnumerable), typeof(ToolbarMenuButton));
