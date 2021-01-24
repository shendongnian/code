    public static T FindChild<T>(DependencyObject d) where T : DependencyObject
    {
        if (d is T)
            return (T)d;
            
        int count = System.Windows.Media.VisualTreeHelper.GetChildrenCount(d);
        for (int i = 0; i < count; i++)
        {
            DependencyObject child = FindChild<T>(System.Windows.Media.VisualTreeHelper.GetChild(d, i));
            if (child != null)
                return (T)child;
        }
            
        return null;
    }
