    _listView.SelectedIndex = index;
    var item = _listView.ItemContainerGenerator.ContainerFromIndex(index) as ListBoxItem;
    if (item != null)
    {
       item.Focus();
    }
    
