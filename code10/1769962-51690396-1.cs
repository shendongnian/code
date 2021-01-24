    private ListViewItem _currentItem = null;
    private void ListViewItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
    {
        var item = sender as ListViewItem;
        if (!Equals(_currentItem, item))
        {
            _currentItem = item;
                    
            // code to update window 
        }
    }
    
    private void ListViewItem_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
    {
        _currentItem = null;
    }
       
