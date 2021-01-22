    public static readonly DependencyProperty TopMarginProperty =
        DependencyProperty.RegisterAttached("TopMargin", typeof(int), typeof(FrameworkElement),
                                            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));
    public static void SetTopMargin(FrameworkElement element, int value)
    {
        // set top margin in element.Margin
    }
    public static int GetTopMargin(FrameworkElement element)
    {
        // get top margin from element.Margin
    }
