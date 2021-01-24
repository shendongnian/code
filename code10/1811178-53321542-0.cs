    private void ListView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
       e.Handled = true;
       DependencyObject originalSource = (DependencyObject)e.OriginalSource;
       while ((originalSource != null && !(originalSource is ListViewItem)))
       {
          originalSource = VisualTreeHelper.GetParent(originalSource);
       }
       if (originalSource != null)
       {
       }
    } 
