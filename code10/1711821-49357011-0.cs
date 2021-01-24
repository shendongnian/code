    private void btnchangesize_Click(object sender, RoutedEventArgs e)
    {
        IEnumerable<GridViewItem> items = FindVisualChildren<GridViewItem>(girdView);
        foreach (var item in items)
        {
            item.Height = 80;
            item.Width = 100;
        }  
    }
    private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
    {
        if (depObj != null)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                if (child != null && child is T)
                {
                    yield return (T)child;
                }
                foreach (T childOfChild in FindVisualChildren<T>(child))
                {
                    yield return childOfChild;
                }
            }
        }
    }
 
 
  
