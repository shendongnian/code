    private void OnCheckBoxClick( object sender, RoutedEventArgs e )
    {
        ListViewItem item = ((CheckBox)sender).FindParent<ListViewItem>();
        if( item != null )
        {
            item.IsSelected = true;
        }
    }
