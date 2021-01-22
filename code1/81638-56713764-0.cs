     private void Scroll_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            // Get the border of the listview (first child of a listview)
            Decorator border = VisualTreeHelper.GetChild(sender as ListView, 0) as Decorator;
            // Get scrollviewer
            ScrollViewer scrollViewer = border.Child as ScrollViewer;
            if (scrollViewer.VerticalOffset == scrollViewer.ScrollableHeight)
            Debug.Print("At the bottom of the list!");
        }
