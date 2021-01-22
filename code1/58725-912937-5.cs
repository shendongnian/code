    IList<Customer> customers = CustomerRepository.GetAllCustomers();  
    IList<Wrapper> wrappedCustomers = customers.Select(c => new Wrapper(c)).ToList();
    /* If you don't like LINQ in the line above you can use foreach to transform
    list of Customer object to a list of Wrapper<Customer> objects */
    comboBoxCustomers.DataSource = wrappedCustomers;
    // or
    dataGridViewCustomers.DataSource = wrappedCustomers;
