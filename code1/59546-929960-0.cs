    private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        DependencyObject obj = (DependencyObject)e.OriginalSource;
    
        while (obj != null && obj != myListView)
        {
            if (obj.GetType() == typeof(ListViewItem))
            {
                // Do something here
                MessageBox.Show("A ListViewItem was double clicked!");
    
                break;
            }
            obj = VisualTreeHelper.GetParent(obj);
        }
    }
