    if (String.IsNullOrEmpty(e.NewTextValue))
    {
        MyListView.ItemsSource = new ObservableCollection<tblItem>(listOfTableItems);
    }
    else
    {
        MyListView.ItemsSource = new ObservableCollection<tblItem>(listOfTableItems
            .Where(x => x.strItemName.ToLowerInvariant().Contains(e.NewTextValue.ToLowerInvariant())));
    }
