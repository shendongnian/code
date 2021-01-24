    private IList<CustomerModelQB> WalkCustomers(ICustomerRetList Customer)
    {
        if (Customer == null) return null;
        _customerList = new List<CustomerModelQB>();
        for (int A = 0; A < Customer.Count; A++)
        {
            ICustomerRet CustomerRet = Customer.GetAt(A);
    
            CustomerModelQB Cust = new CustomerModelQB
            {
                ListID = CustomerRet.ListID.GetValue(),
                EditSequence = CustomerRet.EditSequence.GetValue(),
                Name = CustomerRet.Name.GetValue()
            };
            if (CustomerRet.AccountNumber != null)
                Cust.AccountNumber = CustomerRet.AccountNumber.GetValue();
		    Cust.FullName = CustomerRet.FullName.GetValue();
		
            if (Cust.FullName == null || (Cust.FullName != null && Cust.FullName.StartsWith("***")))
            continue;
            _customerList.Add(Cust);
        }
    
        return _customerList;
    }
