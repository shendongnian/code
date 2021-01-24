    public static readonly DependencyProperty HmiFieldProperty =
        DependencyProperty.Register(
            nameof(HmiField), typeof(double), typeof(UserControl1),
            new FrameworkPropertyMetadata(
                0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
