    public enum CaptionPosition { None, ToLeftOfIcon, AboveIcon, ToRightOfIcon, BelowIcon }
    public enum IconSize { Small, Medium, Large, XLarge, XxLarge }
    public class myXamlIconHost : Control
    {
        private static readonly Brush DefaultForeground = new SolidColorBrush(Color.FromRgb(32,32,32));
        private static readonly Brush DefaultHighlight = Brushes.DarkOrange;
        private static readonly Brush DefaultDisabledForeground = new SolidColorBrush(Color.FromRgb(192, 192, 192));
        private static readonly Brush DefaultDisabledHighlight = new SolidColorBrush(Color.FromRgb(128, 128, 128));
        static myXamlIconHost()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(myXamlIconHost), new FrameworkPropertyMetadata(typeof(myXamlIconHost)));
        }
        public FrameworkElement XamlIcon
        {
            get { return (FrameworkElement)GetValue(XamlIconProperty); }
            set { SetValue(XamlIconProperty, value); }
        }
        public static readonly DependencyProperty XamlIconProperty =
            DependencyProperty.Register("XamlIcon", typeof(FrameworkElement), typeof(myXamlIconHost), new PropertyMetadata(null));
        public IconSize IconSize
        {
            get { return (IconSize)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }
        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register("IconSize", typeof(IconSize), typeof(myXamlIconHost), new PropertyMetadata(IconSize.Medium));
        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(myXamlIconHost), new PropertyMetadata(null));
        public CaptionPosition CaptionPosition
        {
            get { return (CaptionPosition)GetValue(CaptionPositionProperty); }
            set { SetValue(CaptionPositionProperty, value); }
        }
        public static readonly DependencyProperty CaptionPositionProperty =
            DependencyProperty.Register("CaptionPosition", typeof(CaptionPosition), typeof(myXamlIconHost), new PropertyMetadata(CaptionPosition.ToRightOfIcon));
        public Brush StandardForeground
        {
            get { return (Brush)GetValue(StandardForegroundProperty); }
            set { SetValue(StandardForegroundProperty, value); }
        }
        public static readonly DependencyProperty StandardForegroundProperty =
            DependencyProperty.Register("StandardForeground", typeof(Brush), typeof(myXamlIconHost), new PropertyMetadata(DefaultForeground));
        public Brush StandardHighlight
        {
            get { return (Brush)GetValue(StandardHighlightProperty); }
            set { SetValue(StandardHighlightProperty, value); }
        }
        public static readonly DependencyProperty StandardHighlightProperty =
            DependencyProperty.Register("StandardHighlight", typeof(Brush), typeof(myXamlIconHost), new PropertyMetadata(DefaultHighlight));
        public Brush DisabledForeground
        {
            get { return (Brush)GetValue(DisabledForegroundProperty); }
            set { SetValue(DisabledForegroundProperty, value); }
        }
        public static readonly DependencyProperty DisabledForegroundProperty =
            DependencyProperty.Register("DisabledForeground", typeof(Brush), typeof(myXamlIconHost), new PropertyMetadata(DefaultDisabledForeground));
        public Brush DisabledHighlight
        {
            get { return (Brush)GetValue(DisabledHighlightProperty); }
            set { SetValue(DisabledHighlightProperty, value); }
        }
        public static readonly DependencyProperty DisabledHighlightProperty =
            DependencyProperty.Register("DisabledHighlight", typeof(Brush), typeof(myXamlIconHost), new PropertyMetadata(DefaultDisabledHighlight));
    }
    // ==============================================================================================================================================
    public class myXamlIconSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            const int defaultSize = 24;
            if (!(value is IconSize))
                return defaultSize;
            var iconSizeValue = (IconSize)value;
            switch (iconSizeValue)
            {
                case IconSize.Small:
                    return defaultSize * 2 / 3;
                case IconSize.Large:
                    return defaultSize * 3 / 2;
                case IconSize.XLarge:
                    return defaultSize * 2;
                case IconSize.XxLarge:
                    return defaultSize * 5 / 2;
                default:
                    return defaultSize;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
