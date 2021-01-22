    T GetFirstChildOfType<T>(DependencyObject visual) where T:DependencyObject
    {
      var itemCount = VisualTreeHelper.GetChildrenCount(visual);
      if (itemCount < 1)
      {
        return null;
      }
    
      for (int i = 0; i < itemCount; i++)
      {
        var dp = VisualTreeHelper.GetChild(visual, i);
        if (dp is T)
        {
          return (T)dp;
        }
      }
      for (int i = 0; i < itemCount; i++)
      {
        var dp = GetFirstChildOfType<T>(VisualTreeHelper.GetChild(visual, i));
        if (dp != null) return dp;
      }
      return null;
    }
