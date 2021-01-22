    void CreateNewCustomer()
    {
        Customer newCustomer = Customer.CreateNewCustomer();
        CustomerViewModel workspace = new CustomerViewModel(newCustomer, _customerRepository);
        this.Workspaces.Add(workspace);
        this.SetActiveWorkspace(workspace);
    }
