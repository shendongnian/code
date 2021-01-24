    /// <summary>
    /// The placeholder property.
    /// </summary>
    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        nameof(Placeholder),
        typeof(string),
        typeof(CustomPickerCell),
        propertyChanged: (bindable, oldVal, newVal) => ((CustomPickerCell)bindable).OnPlaceholderChanged((string)newVal)
    );
    
    /// <summary>
    /// The items source property.
    /// </summary>
    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
        nameof(ItemsSource),
        typeof(IList),
        typeof(CustomPickerCell),
        propertyChanged: (bindable, oldVal, newVal) => ((CustomPickerCell)bindable).OnItemsSourceChanged((IList)newVal)
    );
    
    /// <summary>
    /// The selected item property.
    /// </summary>
    public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
        nameof(SelectedItem),
        typeof(object),
        typeof(CustomPickerCell),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: (bindable, oldVal, newVal) => ((CustomPickerCell)bindable).OnSelectedItemChanged((object)newVal)
    );
    
    /// <summary>
    /// The item display binding property
    /// NOTE: Use the name of the property, you do not need to bind to this property.
    /// </summary>
    public static readonly BindableProperty ItemDisplayBindingProperty = BindableProperty.Create(
        nameof(ItemDisplayBinding),
        typeof(string),
        typeof(CustomPickerCell),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: (bindable, oldVal, newVal) => ((CustomPickerCell)bindable).OnItemDisplayBindingChanged((string)newVal)
    );
