    public static DependencyObject FindInVisualTreeDown(DependencyObject obj, Type type)
    {
        if (obj != null)
        {
            if (obj.GetType() == type)
            {
                return obj;
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject childReturn = FindInVisualTreeDown(VisualTreeHelper.GetChild(obj, i), type);
                if (childReturn != null)
                {
                    return childReturn;
                }
            }
        }
        return null;
    }
