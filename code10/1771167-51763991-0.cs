    public class SyncBehavior : Behavior<ScrollViewer>
    {
    
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += OnAssociatedObjectLoaded;
            AssociatedObject.LayoutUpdated += OnAssociatedObjectLayoutUpdated;
        }
    
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Loaded -= OnAssociatedObjectLoaded;
            AssociatedObject.LayoutUpdated -= OnAssociatedObjectLayoutUpdated;
        }
    
        private void OnAssociatedObjectLayoutUpdated(object sender, object o)
        {
            SyncPointOffSetY();
        }
    
        private void OnAssociatedObjectLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            SyncPointOffSetY();
            AssociatedObject.Loaded -= OnAssociatedObjectLoaded;
        }
    
        private void SyncPointOffSetY()
        {
            if (AssociatedObject == null) return;
    
            AssociatedObject.ViewChanged += AssociatedObject_ViewChanged;
        }
    
        private void AssociatedObject_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            var MyScrollViewer = sender as ScrollViewer;
            this.SetValue(PointOffSetYProperty, MyScrollViewer.VerticalOffset);
    
        }
    
        public double PointOffSetY
        {
            get { return (double)GetValue(PointOffSetYProperty); }
            set { SetValue(PointOffSetYProperty, value); }
        }
    
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PointOffSetYProperty =
            DependencyProperty.Register("PointOffSetY", typeof(double), typeof(SyncBehavior), new PropertyMetadata(0.0, CallBack));
    
        private static void CallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as SyncBehavior;
            var temScrollViewer = current.AssociatedObject;
            if (e.NewValue != e.OldValue & (double)e.NewValue != 0)
            {
                temScrollViewer.ScrollToVerticalOffset((double)e.NewValue);
            }
        }
    
    
    }
 
