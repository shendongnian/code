    public static void OrderTreeSetup(ObservableCollection<tblProject> table,
        ListSortDirection direction)
    {
        ConfigureSortingRecursive(table, direction);
        //...all further initializations you need to do...
    }
    private static void ConfigureSortingRecursive(IEnumerable<object> entities,
        ListSortDirection direction)
    {
        ICollectionView view = CollectionViewSource.GetDefaultView(entities);
        view.SortDescriptions.Clear();
        view.SortDescriptions.Add(new SortDescription("Name", direction));
        foreach (object entity in entities) {
            if (entity is ICascadingSetup cascadingSetup) {
                ConfigureSortingRecursive(cascadingSetup.Children, direction);
            }
        }
    }
