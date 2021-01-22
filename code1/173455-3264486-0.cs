    public static readonly DependencyProperty IsBubbleSourceProperty = DependencyProperty.RegisterAttached(
        "IsBubbleSource",
        typeof(Boolean),
        typeof(TestBox),
        new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits)
        );
