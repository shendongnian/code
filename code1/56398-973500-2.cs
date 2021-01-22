    private static void OnPreviewMouseWheelScrolled(object sender, MouseWheelEventArgs e)
    {
        DependencyObject scrollHost = sender as DependencyObject;
        double scrollSpeed = (double)(scrollHost).GetValue(Demo.ScrollSpeedProperty);
        ScrollViewer scrollViewer = GetScrollViewer(scrollHost) as ScrollViewer;
        if (scrollViewer != null)
        {
            double offset = scrollViewer.VerticalOffset - (e.Delta * scrollSpeed / 6);
            if (offset < 0)
            {
                scrollViewer.ScrollToVerticalOffset(0);
            }
            else if (offset > scrollViewer.ExtentHeight)
            {
                scrollViewer.ScrollToVerticalOffset(scrollViewer.ExtentHeight);
            }
            else
            {
                scrollViewer.ScrollToVerticalOffset(offset);
            }
            
            e.Handled = true;
        }
        else
        {
            throw new NotSupportedException("ScrollSpeed Attached Property is not attached to an element containing a ScrollViewer.");
        }
    }
