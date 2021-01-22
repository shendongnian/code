    private bool _should_auto_scroll = true;
    private void ScrollViewer_OnScrollChanged(object sender, ScrollChangedEventArgs e) {
        if (Math.Abs(e.ExtentHeightChange) < float.MinValue) {
            _should_auto_scroll = Math.Abs(ScrollViewer.VerticalOffset - ScrollViewer.ScrollableHeight) < float.MinValue;
        }
        if (_should_auto_scroll && Math.Abs(e.ExtentHeightChange) > float.MinValue) {
            ScrollViewer.ScrollToVerticalOffset(ScrollViewer.ExtentHeight);
        }
    }
