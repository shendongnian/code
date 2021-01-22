    private void ItemsList_DragOver(object sender, System.Windows.DragEventArgs e)
    {
        ListBox li = sender as ListBox;
        ScrollViewer sv = FindVisualChild<ScrollViewer>(ItemsList);
        double tolerance = 10;
        double verticalPos = e.GetPosition(li).Y;
        double offset = 3;
        if (verticalPos < tolerance) // Top of visible list?
        {
            sv.ScrollToVerticalOffset(sv.VerticalOffset - offset); //Scroll up.
        }
        else if (verticalPos > li.ActualHeight - tolerance) //Bottom of visible list?
        {
            sv.ScrollToVerticalOffset(sv.VerticalOffset + offset); //Scroll down.    
        }
    }
    public static childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
    {
        // Search immediate children first (breadth-first)
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(obj, i);
            if (child != null && child is childItem)
                return (childItem)child;
            else
            {
                childItem childOfChild = FindVisualChild<childItem>(child);
                if (childOfChild != null)
                    return childOfChild;
            }
        }
        return null;
    }
