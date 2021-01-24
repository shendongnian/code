    public IQueryable<CustomerViewModel> GetCustomerViewModels()
    {
        return _context.Customer.Select(
            customer => new CustomerViewModel
            {
                // <assign properties here>
            }
        );
    }
