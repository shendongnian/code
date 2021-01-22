    public class ScrollToOffsetBehavior : Behavior<ScrollViewer>
    {
        private FrameworkElement contentElement = null;
        
        public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register(
            "Offset",
            typeof(double),
            typeof(ScrollToOffsetBehavior),
            new PropertyMetadata(0.0));
        public double Offset
        {
            get { return (double)GetValue(OffsetProperty); }
            set { SetValue(OffsetProperty, value); }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            if (this.AssociatedObject != null)
            {
                this.AssociatedObject.Loaded += new RoutedEventHandler(AssociatedObject_Loaded);
            }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (this.contentElement != null)
            {
                this.contentElement.SizeChanged -= contentElement_SizeChanged;
            }
            if (this.AssociatedObject != null)
            {
                this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            }
        }
        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            this.contentElement = this.AssociatedObject.Content as FrameworkElement;
            if (this.contentElement != null)
            {
                this.contentElement.SizeChanged += new SizeChangedEventHandler(contentElement_SizeChanged);
            }
        }
        void contentElement_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.AssociatedObject.ScrollToVerticalOffset(this.Offset);
        }
    }
