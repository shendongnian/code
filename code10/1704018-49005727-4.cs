    public static IEnumerable<T> FindChildren<T>(DependencyObject d) where T : DependencyObject
    {
        if (d is T)
            yield return (T)d;
        int count = System.Windows.Media.VisualTreeHelper.GetChildrenCount(d);
        for (int i = 0; i < count; i++)
        {
            foreach (T child in FindChildren<T>(System.Windows.Media.VisualTreeHelper.GetChild(d, i)))
                yield return child;
        }
    }
