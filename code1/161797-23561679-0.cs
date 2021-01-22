    public static class ScrollViewerEx
    {
        public static readonly DependencyProperty AutoScrollProperty =
            DependencyProperty.RegisterAttached("AutoScrollToEnd", 
                typeof(bool), typeof(ScrollViewer), new PropertyMetadata(false));
        public static readonly DependencyProperty AutoScrollHandlerProperty =
            DependencyProperty.RegisterAttached("AutoScrollToEndHandler", 
                typeof(ScrollViewerAutoScrollToEndHandler), typeof(ScrollViewer));
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
