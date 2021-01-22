    using (var childContainer = _container.CreateChildContainer())
    {
        childContainer.RegisterInstance(customerId);
        var custView = childContainer.Resolve<CustomerDataView>();
        manager.Regions[RegionNames.Sidebar].AddAndActivate(custView);
    }
