    public static class VisualTreeExt
    {
      public static IEnumerable<T> GetDescendants<T>(DependencyObject parent) where T : DependencyObject
      {
        var count = VisualTreeHelper.GetChildrenCount(parent);
        for (var i = 0; i < count; ++i)
        {
           // Obtain the child
           var child = VisualTreeHelper.GetChild(parent, i);
           if (child is T)
             yield return (T)child;
           // Return all the descendant children
           foreach (var subItem in GetDescendants<T>(child))
             yield return subItem;
        }
      }
    }
