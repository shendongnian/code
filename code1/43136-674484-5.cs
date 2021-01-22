    static TObject FindVisualParent<TObject>(UIElement child) where TObject : UIElement
    {
      if (child == null)
      {
        return null;
      }
    
      UIElement parent = VisualTreeHelper.GetParent(child) as UIElement;
    
      while (parent != null)
      {
        TObject found = parent as TObject;
        if (found != null)
        {
          return found;
        }
        else
        {
          parent = VisualTreeHelper.GetParent(parent) as UIElement;
        }
      }
    
      return null;
    }
