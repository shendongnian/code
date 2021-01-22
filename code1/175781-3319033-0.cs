    public Boolean AllowClose
    {
        get { return (Boolean)GetValue(AllowCloseProperty); }
        set { SetValue(AllowCloseProperty, value); }
    }
     public static readonly DependencyProperty AllowCloseProperty =
        DependencyProperty.Register("AllowClose", typeof(Boolean), 
        typeof(MyUserControl), new UIPropertyMetadata(false));
