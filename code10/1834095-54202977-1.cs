    private List<SexType> _currentFilters = new List<SexType>();
    public FilteringSample()
    {
        InitializeComponent();
        List<User> items = new List<User>();
        items.Add(new User() { Name = "John Doe", Age = 42, Sex = SexType.Male });
        items.Add(new User() { Name = "Jane Doe", Age = 39, Sex = SexType.Female });
        items.Add(new User() { Name = "Sammy Doe", Age = 13, Sex = SexType.Male });
        lvUsers.ItemsSource = items;
        UpdateFilters();
        CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
        PropertyGroupDescription groupDescription = new PropertyGroupDescription("Sex");
        view.GroupDescriptions.Add(groupDescription);
        view.Filter = UserFilter;
    }
    private bool UserFilter(object item)
    {
        return _currentFilters.Contains(((User)item).Sex);
    }
    private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateFilters();
        CollectionViewSource.GetDefaultView(lvUsers.ItemsSource).Refresh();
    }
    private void UpdateFilters()
    {
        //Select the SexType(s) of the Users matching the current txtFilter name filter, or of all Users if txtFilter is empty
        string searchString = txtFilter.Text;
        IEnumerable<User> users = lvUsers.ItemsSource as IEnumerable<User>;
        if(!String.IsNullOrWhiteSpace(searchString))
            users = users.Where(u => u.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0);
        _currentFilters = users.Select(u => u.Sex)
                                .Distinct()
                                .ToList();
    }
