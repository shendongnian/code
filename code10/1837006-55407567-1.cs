    /// <summary>
    /// The cell's placeholder (select a ....).
    /// </summary>
    /// <value>The placeholder.</value>
    public string Placeholder
    {
        get { return (string)GetValue(PlaceholderProperty); }
        set { SetValue(PlaceholderProperty, value); }
    }
    
    /// <summary>
    /// The cell's picker item source.
    /// </summary>
    /// <value>The items source.</value>
    public IList ItemsSource
    {
        get { return (IList)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }
    
    /// <summary>
    /// Gets or sets the selected item.
    /// </summary>
    /// <value>The selected item.</value>
    public object SelectedItem
    {
        get { return GetValue(SelectedItemProperty); }
        set { SetValue(SelectedItemProperty, value); }
    }
    
    /// <summary>
    /// Gets or sets the item display binding.
    /// </summary>
    /// <value>The item display binding.</value>
    public string ItemDisplayBinding
    {
        get { return (string)GetValue(ItemDisplayBindingProperty); }
        set { SetValue(ItemDisplayBindingProperty, value); }
    }
