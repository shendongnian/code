    // MinimizedContent
    public static readonly DependencyProperty MinimizedContentProperty
        = DependencyProperty.Register("MinimizedContent", typeof(object), typeof(SwappableContentControl),
        new PropertyMetadata(new PropertyChangedCallback(OnMinimizedContentChanged)));
    
    public object MinimizedContent
    {
        get { return GetValue(MinimizedContentProperty); }
        set { SetValue(MinimizedContentProperty, value); }
    }
    
    private static void OnMinimizedContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        SwappableContentControl swappableContentControl = d as SwappableContentControl;
        if (swappableContentControl == null)
            return;
    
        swappableContentControl.RemoveLogicalChild(e.OldValue);
        swappableContentControl.AddLogicalChild(e.NewValue);
    }
