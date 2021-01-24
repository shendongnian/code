    internal class MyCollection<T> : ObservableCollection<T> 
    {
        public void DoCollectionChanged()
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
        ... MyCollection<LebensmittelItem> LebensmittelList; // field and property declaration should be changed
    public void RefreshListView(string searchBarText)
    {
        // this can be list clearing, if you need it
        addItemInCollection(searchBarText);
        LebensmittelList.DoCollectionChanged();
    }
