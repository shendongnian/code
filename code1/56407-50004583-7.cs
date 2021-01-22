         private void HandleScrollSpeed(object sender, MouseWheelEventArgs e)
            {
                try
                {
                    if (!(sender is DependencyObject))
                        return;
        
                    ScrollViewer scrollViewer = (((DependencyObject)sender)).GetScrollViewer() as ScrollViewer;
                    ListBox lbHost = sender as ListBox; //Or whatever your UI element is
        
                    if (scrollViewer != null && lbHost != null)
                    {
                        double scrollSpeed = 1;
        //you may check here your own conditions
                        if (lbHost.Name == "SourceListBox" || lbHost.Name == "TargetListBox")
                            scrollSpeed = 2;
        
                        double offset = scrollViewer.VerticalOffset - (e.Delta * scrollSpeed / 6);
                        if (offset < 0)
                            scrollViewer.ScrollToVerticalOffset(0);
                        else if (offset > scrollViewer.ExtentHeight)
                            scrollViewer.ScrollToVerticalOffset(scrollViewer.ExtentHeight);
                        else
                            scrollViewer.ScrollToVerticalOffset(offset);
        
                        e.Handled = true;
                    }
                    else
                        throw new NotSupportedException("ScrollSpeed Attached Property is not attached to an element containing a ScrollViewer.");
                }
                catch (Exception ex)
                {
    //Do something...
                }
            }
