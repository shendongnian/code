    public static class ScrollViewerEx
    {
        public static readonly DependencyProperty AutoScrollProperty =
            DependencyProperty.RegisterAttached("AutoScrollToEnd", 
                typeof(bool), typeof(ScrollViewerEx), 
                new PropertyMetadata(false, HookupAutoScrollToEnd));
        public static readonly DependencyProperty AutoScrollHandlerProperty =
            DependencyProperty.RegisterAttached("AutoScrollToEndHandler", 
                typeof(ScrollViewerAutoScrollToEndHandler), typeof(ScrollViewerEx));
        private static void HookupAutoScrollToEnd(DependencyObject d, 
                DependencyPropertyChangedEventArgs e)
        {
            var scrollViewer = d as ScrollViewer;
            if (scrollViewer == null) return;
            SetAutoScrollToEnd(scrollViewer, (bool)e.NewValue);
        }
        public static bool GetAutoScrollToEnd(ScrollViewer instance)
        {
            return (bool)instance.GetValue(AutoScrollProperty);
        }
        public static void SetAutoScrollToEnd(ScrollViewer instance, bool value)
        {
            var oldHandler = (ScrollViewerAutoScrollToEndHandler)instance.GetValue(AutoScrollHandlerProperty);
            if (oldHandler != null)
            {
                oldHandler.Dispose();
                instance.SetValue(AutoScrollHandlerProperty, null);
            }
            instance.SetValue(AutoScrollProperty, value);
            if (value)
                instance.SetValue(AutoScrollHandlerProperty, new ScrollViewerAutoScrollToEndHandler(instance));
        }
