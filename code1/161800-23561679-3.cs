    public class ScrollViewerAutoScrollToEndHandler : DependencyObject, IDisposable
    {
        readonly ScrollViewer m_scrollViewer;
        bool m_doScroll = false;
        public ScrollViewerAutoScrollToEndHandler(ScrollViewer scrollViewer)
        {
            if (scrollViewer == null) { throw new ArgumentNullException("scrollViewer"); }
            m_scrollViewer = scrollViewer;
            m_scrollViewer.ScrollToEnd();
            m_scrollViewer.ScrollChanged += ScrollChanged;
        }
        private void ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            // User scroll event : set or unset autoscroll mode
            if (e.ExtentHeightChange == 0) 
            { m_doScroll = m_scrollViewer.VerticalOffset == m_scrollViewer.ScrollableHeight; }
            // Content scroll event : autoscroll eventually
            if (m_doScroll && e.ExtentHeightChange != 0) 
            { m_scrollViewer.ScrollToVerticalOffset(m_scrollViewer.ExtentHeight); }
        }
        public void Dispose()
        {
            m_scrollViewer.ScrollChanged -= ScrollChanged;
        }
