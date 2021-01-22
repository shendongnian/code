    var collection = new ObservableCollection<int>();
            
    collection.Add(7);
    collection.Add(4);
    collection.Add(12);
    collection.Add(1);
    collection.Add(20);
    // ascending
    collection = new ObservableCollection<int>(collection.OrderBy(a => a));
    // descending
    collection = new ObservableCollection<int>(collection.OrderByDescending(a => a));
