    public static readonly DependencyProperty IsExpandedProperty = 
            DependencyProperty.Register("IsExpanded", typeof(bool), typeof(Dock), 
            new FrameworkPropertyMetadata(true,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnIsExpandedChanged));
    public bool IsExpanded
    {
        get { return (bool)GetValue(IsExpandedProperty); }
        set { SetValue(IsExpandedProperty, value); }
    }
