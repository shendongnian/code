    [Test]
    public void AddComponentInstance()
    {
        CustomerImpl customer = new CustomerImpl();
        kernel.AddComponentInstance("key", typeof(ICustomer), customer);
        Assert.IsTrue(kernel.HasComponent("key"));
        CustomerImpl customer2 = kernel["key"] as CustomerImpl;
        Assert.AreSame(customer, customer2);
        customer2 = kernel[typeof(ICustomer)] as CustomerImpl;
        Assert.AreSame(customer, customer2);
    }
    [Test]
    public void AddComponentInstance_ByService()
    {
        CustomerImpl customer = new CustomerImpl();
        kernel.AddComponentInstance <ICustomer>(customer);
        Assert.AreSame(kernel[typeof(ICustomer)],customer);
    }
    [Test]
    public void AddComponentInstance2()
    {
        CustomerImpl customer = new CustomerImpl();
        kernel.AddComponentInstance("key", customer);
        Assert.IsTrue(kernel.HasComponent("key"));
        CustomerImpl customer2 = kernel["key"] as CustomerImpl;
        Assert.AreSame(customer, customer2);
        customer2 = kernel[typeof(CustomerImpl)] as CustomerImpl;
        Assert.AreSame(customer, customer2);
    }
