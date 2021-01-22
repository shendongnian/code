    void OnListViewItem_PreviewMouseButtonDown(object sender, MouseButtonEventArgs e)
    {
      if (e.Handled)
        return;
    
      ListViewItem item = MyVisualTreeHelper.FindParent<ListViewItem>((DependencyObject)e.OriginalSource);
      if (item == null)
        return;
    
      if (item.Focusable && !item.IsFocused)
        item.Focus();
    }
