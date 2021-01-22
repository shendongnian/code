    [System.Runtime.CompilerServices.Extension()]
    public ObservableCollection<T> ToObservableCollection<T>(IEnumerable<T> list)
    {
        ObservableCollection<T> collection = new ObservableCollection<T>();
        
        foreach (T l in list) {
            collection.Add(l);
        }
        
        return collection;
    }
