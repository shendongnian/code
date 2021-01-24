    public static readonly DependencyProperty RangeProperty = DependencyProperty.Register(
        nameof(Range),
        typeof(double), 
        typeof(DepthIndicatorTickBar), 
        new FrameworkPropertyMetadata(
            100d, 
            FrameworkPropertyMetadataOptions.AffectsMeasure |
            FrameworkPropertyMetadataOptions.AffectsRender));
