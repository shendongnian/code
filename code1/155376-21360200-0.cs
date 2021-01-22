    private static bool ScrollToOffset(DependencyObject n, double offset)
    {
        bool terminate = false;
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(n); i++)
        {
            var child = VisualTreeHelper.GetChild(n, i);
            if (child is ScrollViewer)
            {
                (child as ScrollViewer).ScrollToVerticalOffset(offset);
                return true;
            }
        }
        if (!terminate)
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(n); i++)
                terminate = ScrollToOffset(VisualTreeHelper.GetChild(n, i), offset);
         return false;
    }
