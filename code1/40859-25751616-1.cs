    CustomerTable customer = new CustomerTable();
    UserTable user = new UserTable();
    user.Name = customer.Name; //*** No longer breaks internal data structures
    user.Name = "string literal";  // Works as expected with implicit cast operator
    user.Name = (string)customer.Name; // Still allowed with explicit/implicit cast operator
    user.Name = customer.Name.Value; // Also works if Value property is still defined
