    public static IEnumerable<T> GetVisualChildren<T>(this DependencyObject parent) where T : DependencyObject
    {
        if (parent == null)
        {
            yield return null;
        }
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(parent, i);
            if (child is T t)
            {
                yield return t;
            }
            foreach (T childrensChild in child.FindVisualChildren<T>())
            {
                yield return childrensChild;
            }
        }
    }
