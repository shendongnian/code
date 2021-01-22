    private static void ScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
    {
        ScrollViewer scrollViewer = (ScrollViewer)sender;
        FrameworkElement origicalControlSender = e.OriginalSource as FrameworkElement;
    
        ScrollViewer closestScrollViewer = origicalControlSender.GetParent<ScrollViewer>();
    
        if (closestScrollViewer != null && !ReferenceEquals(closestScrollViewer, scrollViewer))
        {
            return;
        }
    
        scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta);
        e.Handled = true;
    }
    public static T GetParent<T>(this FrameworkElement control)
        where T : DependencyObject
    {
        FrameworkElement parentElement = control?.Parent as FrameworkElement;
    
        if (parentElement == null)
        {
            return null;
        }
    
        T parent = parentElement as T;
    
        if (parent != null)
        {
            return parent;
        }
    
        return GetParent<T>(parentElement);
    }
