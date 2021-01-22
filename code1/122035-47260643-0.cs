    /// <summary>
    /// VerticalOffset attached property
    /// </summary>
    public static readonly DependencyProperty VerticalOffsetProperty =
        DependencyProperty.RegisterAttached("VerticalOffset", typeof(double),
        typeof(ScrollViewerBinding), new FrameworkPropertyMetadata(double.NaN,
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnVerticalOffsetPropertyChanged));
                 OnVerticalOffsetPropertyChanged));
    
    /// <summary>
    /// Just a flag that the binding has been applied.
    /// </summary>
    private static readonly DependencyProperty VerticalScrollBindingProperty =
        DependencyProperty.RegisterAttached("VerticalScrollBinding", typeof(bool?), typeof(ScrollViewerBinding));
    
    public static double GetVerticalOffset(DependencyObject depObj)
    {
        return (double)depObj.GetValue(VerticalOffsetProperty);
    }
    
    public static void SetVerticalOffset(DependencyObject depObj, double value)
    {
        depObj.SetValue(VerticalOffsetProperty, value);
    }
    
    private static void OnVerticalOffsetPropertyChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        ScrollViewer scrollViewer = d as ScrollViewer;
        if (scrollViewer == null)
            return;
    
        BindVerticalOffset(scrollViewer);
        scrollViewer.ScrollToVerticalOffset((double)e.NewValue);
    }
    
    public static void BindVerticalOffset(ScrollViewer scrollViewer)
    {
        if (scrollViewer.GetValue(VerticalScrollBindingProperty) != null)
            return;
    
        scrollViewer.SetValue(VerticalScrollBindingProperty, true);
        scrollViewer.ScrollChanged += (s, se) =>
        {
            if (se.VerticalChange == 0)
                return;
            SetVerticalOffset(scrollViewer, se.VerticalOffset);
        };
    }
