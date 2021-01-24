    public static T FindChild<T>(DependencyObject d) where T : DependecyObject
    {
        try
        {
            T current = d as T;
            if (d != null && current == null)
            {
                int count = System.Windows.Media.VisualTreeHelper.GetChildrenCount(d);
                for (int i = 0; i < count; i++)
                {
                    current = FindChild<T>(System.Windows.Media.VisualTreeHelper.GetChild(d, i));
                    if (current != null)
                        break;
                }
            }
            return current;
        }
        catch
        {
            return null;
        }
    }
