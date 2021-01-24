    public void Go()
    {
        ICustomerService _customerService = new CustomerService();
        _customerService.DoOtherStuff();
        var name = _customerService.GetName(); // ICustomerService has a GetName() method now
    }
