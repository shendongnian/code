    private Dictionary<string, List<UserControl>> _leftSubMenuItems =
        new Dictionary<string, List<UserControl>>();
    if (!_leftSubMenuItems.ContainsKey("customers"))
    {
        _leftSubMenuItems["customers"] = new List<UserControl>();
    }
    _leftSubMenuItems["customers"].Add(container.Resolve<EditCustomer>());
    _leftSubMenuItems["customers"].Add(container.Resolve<CustomerReports>());
