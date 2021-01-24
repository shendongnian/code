    public Task<List<CustomerViewModel>> GetCustomerViewModels(
        int skip = 0,
        int take = 100
    )
    {
        return _context.Customer
            .Skip(skip)
            .Take(take)
            .Select(customer => new CustomerViewModel
            {
                // <assign properties here>
            })
            .ToListAsync();
    }
