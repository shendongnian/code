    private IEnumerable<TreeViewEntry> OrganizationsToTreeViewEntries(IEnumerable<Organization> orgs)
    {
        return (from o in orgs
                select new TreeViewEntry
                {
                    Name = o.Name,
                    Model = o,
                    Children = (from u in o.Users
                                select new TreeViewEntry
                                {
                                    Name = u.Name,
                                    Model = u
                                }
                                ).Concat(OrganizationsToTreeViewEntries(o.Children))
                });
    }
    public MainPage()
    {
        InitializeComponent();
        var items = OrganizationsToTreeViewEntries(existingOrganizationData);
        OrgTree.ItemsSource = items;
    }
