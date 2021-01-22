    public void Add(T item)
    {
        // null-check omitted for simplicity
        item.PropertyChanged += ItemPropertyChanged;
        _List.Add(item);
    }
