    public static IEnumerable<T> FindChildren<T>(this DependencyObject @this) where T : DependencyObject
    {
        if (@this == null)
            yield break;
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(@this); i++)
        {
            var child = VisualTreeHelper.GetChild(@this, i);
            var result = child as T;
            if (result != null)
                yield return result;
            foreach (var value in FindChildren<T>(child))
                yield return value;
        }
        yield break;
    }
