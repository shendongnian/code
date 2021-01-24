    public static readonly DependencyProperty CustomizableColumnsProperty =
        DependencyProperty.Register(
            nameof(CustomizableColumns),
            typeof(ObservableCollection<DataGridColumn>),
            typeof(DataGridCustomizable));
    ...
    public DataGridCustomizable()
    {
        SetCurrentValue(CustomizableColumnsProperty,
            new ObservableCollection<DataGridColumn>());
    } 
