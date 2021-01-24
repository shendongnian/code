    /// <summary>
    /// Called when PlaceholderProperty changes.
    /// </summary>
    /// <param name="newVal">New value.</param>
    private void OnPlaceholderChanged(string newVal)
    {
        ItemPicker.Title = newVal;
    }
    
    /// <summary>
    /// Called when ItemSourceProperty changes.
    /// </summary>
    private void OnItemsSourceChanged(IList list)
    {
        ItemPicker.ItemsSource = list;
    }
    
    /// <summary>
    /// Called when SelectedItemProperty changes.
    /// </summary>
    /// <param name="obj">Object.</param>
    private void OnSelectedItemChanged(object obj)
    {
        ItemPicker.SelectedItem = obj;
    }
    
    /// <summary>
    /// Called when ItemDisplayBindingProperty changes.
    /// </summary>
    /// <param name="newvalue">Newvalue.</param>
    private void OnItemDisplayBindingChanged(string newvalue)
    {
        ItemPicker.ItemDisplayBinding = new Binding(newvalue);
    }
