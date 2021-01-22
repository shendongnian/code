    public static DependencyObject FindVisualAncestor(this DependencyObject wpfObject, Predicate<DependencyObject> condition)
    {
        while (wpfObject != null)
        {
            if (condition(wpfObject))
            {
                return wpfObject;
            }
            wpfObject = VisualTreeHelper.GetParent(wpfObject);
        }
        return null;
    }
