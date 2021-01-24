    bool is_programmatic_call = false;
    private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
            
        if (is_programmatic_call)
        {
            is_programmatic_call = false;
            return;
        }
        if(sender == ScrollViewer1)
        {
            ScrollViewer2.ViewChanged -= ScrollViewer_ViewChanged;
            is_programmatic_call = true;
            ScrollViewer2.ChangeView(ScrollViewer1.HorizontalOffset, ScrollViewer1.VerticalOffset, null, true);
            ScrollViewer2.ViewChanged += ScrollViewer_ViewChanged;
        }
        else
        {
            ScrollViewer1.ViewChanged -= ScrollViewer_ViewChanged;
            is_programmatic_call = true;
            ScrollViewer1.ChangeView(ScrollViewer2.HorizontalOffset, ScrollViewer2.VerticalOffset, null, true);
            ScrollViewer1.ViewChanged += ScrollViewer_ViewChanged;
        }
    }
