    public static class MyVisualTreeHelper
    {
      static bool AlwaysTrue<T>(T obj) { return true; }
    
      /// <summary>
      /// Finds a parent of a given item on the visual tree. If the element is a ContentElement or FrameworkElement 
      /// it will use the logical tree to jump the gap.
      /// If not matching item can be found, a null reference is returned.
      /// </summary>
      /// <typeparam name="T">The type of the element to be found</typeparam>
      /// <param name="child">A direct or indirect child of the wanted item.</param>
      /// <returns>The first parent item that matches the submitted type parameter. If not matching item can be found, a null reference is returned.</returns>
      public static T FindParent<T>(DependencyObject child) where T : DependencyObject
      {
        return FindParent<T>(child, AlwaysTrue<T>);
      }
    
      public static T FindParent<T>(DependencyObject child, Predicate<T> predicate) where T : DependencyObject
      {
        DependencyObject parent = GetParent(child);
        if (parent == null)
          return null;
    
        // check if the parent matches the type and predicate we're looking for
        if ((parent is T) && (predicate((T)parent)))
          return parent as T;
        else
          return FindParent<T>(parent);
      }
      static DependencyObject GetParent(DependencyObject child)
      {
        DependencyObject parent = null;
        if (child is Visual || child is Visual3D)
          parent = VisualTreeHelper.GetParent(child);
        // if fails to find a parent via the visual tree, try to logical tree.
        return parent ?? LogicalTreeHelper.GetParent(child);
      }
    }
