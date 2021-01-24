    foreach (Customer customer in Customers)
    {
        if (!customer.Customers.ToUpper().Contains(CustomerSearch.ToUpper()))
        {
            CustomerList.RemoveItemsFromView(customer);
        }
    }
    this.Customers = new ObservableCollection<Customer>(CustomerList);
