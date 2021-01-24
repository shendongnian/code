    private void HandleItemDoubleClick(object sender, RoutedEventArgs e)
    {
        if (((TreeViewItem)sender).DataContext is Item item)
        {
            Debug.WriteLine(item.Name);
        }
    }
