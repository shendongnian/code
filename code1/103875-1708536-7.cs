    private Button _previousButton;
    private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
     if (_previousButton != null)
      _previousButton.Visibility = Visibility.Collapsed;
    
     // Make sure an item is selected
     if (listBox.SelectedItems.Count == 0)
      return;
    
     // Get the first SelectedItem (use a List<object> when 
     // the SelectionMode is set to Multiple)
     object selectedItem = listBox.SelectedItems[0];
     // Get the ListBoxItem from the ContainerGenerator
     ListBoxItem listBoxItem = listBox.ItemContainerGenerator.ContainerFromItem(selectedItem) as ListBoxItem;
     if (listBoxItem == null)
      return;
    
     // Find a button in the WPF Tree
     Button button = FindDescendant<Button>(listBoxItem);
     if (button == null)
      return;
    
     button.Visibility = Visibility.Visible;
     _previousButton = button;
    }
    
    /// <summary>
    /// Finds the descendant of a dependency object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj">The obj.</param>
    /// <returns></returns>
    public static T FindDescendant<T>(DependencyObject obj) where T : DependencyObject
    {
     // Check if this object is the specified type
     if (obj is T)
      return obj as T;
    
     // Check for children
     int childrenCount = VisualTreeHelper.GetChildrenCount(obj);
     if (childrenCount < 1)
      return null;
    
     // First check all the children
     for (int i = 0; i < childrenCount; i++)
     {
      DependencyObject child = VisualTreeHelper.GetChild(obj, i);
      if (child is T)
       return child as T;
     }
    
     // Then check the childrens children
     for (int i = 0; i < childrenCount; i++)
     {
      DependencyObject child = FindDescendant<T>(VisualTreeHelper.GetChild(obj, i));
      if (child != null && child is T)
       return child as T;
     }
    
     return null;
    }
