    private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        var dirtyItem = sender as T;
        if (dirtyItem != null && sourceCollection.LastOrDefault() == dirtyItem)
        {
            T newRow = new T();
            newRow.PropertyChanged += OnItemPropertyChanged;
            sourceCollection.Add(t);
        }
    }
