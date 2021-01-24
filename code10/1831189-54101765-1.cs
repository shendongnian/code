    public FilterWindowViewModel()
    {
        Categories = new ObservableCollection<Category>();
        CategoryView = CollectionViewSource.GetDefaultView(Categories);
        CategoryView.SortDescriptions.Add(new SortDescription("Type", ListSortDirection.Ascending));
        Messenger.Default.Register<CategoryAddedMessage>(this, m => ReceiveCategoryAddedMessage(m));
    }
