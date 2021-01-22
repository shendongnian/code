    private void Source_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                foreach( SomeItem item in e.NewItems)
                {
                   item.PropertyChanged += new PropertyChangedEventHandler(_SomeItem_PropertyChanged); 
                }
                break;
    ....
    **HANDLE OTHER CASES HERE**
    ....
          }
    }
