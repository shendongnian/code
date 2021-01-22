    /// <summary>
    /// Finds the first child in the visual tree by type.
    /// </summary>
    public static T TryFindChild<T>(DependencyObject parent, Func<T, bool> predicate = null) where T : class {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++) {
            var child = VisualTreeHelper.GetChild(parent, i);
            if ((child is T) && (predicate!=null && predicate(child as T))) {
                return (T)((object)child);
            } else {
                T result = TryFindChild<T>(child, predicate);
                if (result != null)
                    return result;
            }
        }
        return null;
    }
