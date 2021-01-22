    private List<CustomerViewModel> GetCustomerViewModelList(IQueryable<Customer> customerList)
    {
        vaar list = from k in customerList
        select new CustomerViewModel
        {
            Id = k.Id,
            Name = k.Name,
            Balance =
                k.Event.Where(z => z.EventType == (int) EventTypes.Income).Sum(z => z.Amount)
        };
        return list.ToList();
    }
    public List<CustomerViewModel> GetCustomerViewModelListForAllCustomers
    {   
        return GetCustomerViewModelList(_repository.List());
    }
    public CustomerViewModel GetCustomerViewModelListForOneCustomers(int id)
    {   
        return GetCustomerViewModelList(_repository.List().Where(c => c.Id == id)).First();
    }
