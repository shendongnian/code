    using System.Windows;
    using System.Windows.Controls;
    namespace CustomControls
    {
        public partial class DynamicScrollViewer : ScrollViewer
        {
            public DynamicScrollViewer()
            {
                InitializeComponent();
            }
            public double DynamicHorizontalOffset
            {
                get { return (double)GetValue(DynamicHorizontalOffsetProperty); }
                set { SetValue(DynamicHorizontalOffsetProperty, value); }
            }
            public static readonly DependencyProperty DynamicHorizontalOffsetProperty =
                DependencyProperty.Register("DynamicHorizontalOffset", typeof(double), typeof(DynamicScrollViewer));
            public double DynamicVerticalOffset
            {
                get { return (double)GetValue(DynamicVerticalOffsetProperty); }
                set { SetValue(DynamicVerticalOffsetProperty, value); }
            }
            public static readonly DependencyProperty DynamicVerticalOffsetProperty =
                DependencyProperty.Register("DynamicVerticalOffset", typeof(double), typeof(DynamicScrollViewer));
            public double DynamicViewportWidth
            {
                get { return (double)GetValue(DynamicViewportWidthProperty); }
                set { SetValue(DynamicViewportWidthProperty, value); }
            }
            public static readonly DependencyProperty DynamicViewportWidthProperty =
                DependencyProperty.Register("DynamicViewportWidth", typeof(double), typeof(DynamicScrollViewer));
            public double DynamicViewportHeight
            {
                get { return (double)GetValue(DynamicViewportHeightProperty); }
                set { SetValue(DynamicViewportHeightProperty, value); }
            }
            public static readonly DependencyProperty DynamicViewportHeightProperty =
                DependencyProperty.Register("DynamicViewportHeight", typeof(double), typeof(DynamicScrollViewer));
            protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
            {
                base.OnPropertyChanged(e);
                if (e.Property == DynamicVerticalOffsetProperty)
                {
                    if (ScrollInfo != null)
                        ScrollInfo.SetVerticalOffset(DynamicVerticalOffset);
                }
                else if (e.Property == DynamicHorizontalOffsetProperty)
                {
                    if (ScrollInfo != null)
                        ScrollInfo.SetHorizontalOffset(DynamicHorizontalOffset);
                }
                else if (e.Property == HorizontalOffsetProperty)
                {
                    DynamicHorizontalOffset = (double)e.NewValue;
                }
                else if (e.Property == VerticalOffsetProperty)
                {
                    DynamicVerticalOffset = (double)e.NewValue;
                }
                else if (e.Property == ViewportWidthProperty)
                {
                    DynamicViewportWidth = (double)e.NewValue;
                }
                else if (e.Property == ViewportHeightProperty)
                {
                    DynamicViewportHeight = (double)e.NewValue;
                }
            }
        }
    }
