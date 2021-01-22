    private void _SomeItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        ListCollectionView lcv = (ListCollectionView)(CollectionViewSource.GetDefaultView(theListBox.ItemsSource));
        lcv.Refresh();
    }
