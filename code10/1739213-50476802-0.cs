    private static void ConfigureSorting(object entity, ListSortDirection direction)
    {
        ICollectionView view = CollectionViewSource.GetDefaultView(entity);
        view.SortDescriptions.Clear();
        view.SortDescriptions.Add(new SortDescription("Name", direction));
    }
