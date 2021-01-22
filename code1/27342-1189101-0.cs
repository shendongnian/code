    private void Button_Click(object sender, RoutedEventArgs e)
    {
       DependencyObject dep = (DependencyObject)e.OriginalSource;
       while ((dep != null) && !(dep is ListViewItem))
       {
         dep = VisualTreeHelper.GetParent(dep);
       }
       if (dep == null)
        return;
       int index = lstBox.ItemContainerGenerator.IndexFromContainer(dep); 
    }
