    public async Task<List<CustomerViewModel>> GetCustomerViewModels(
        int skip,
        int take
    )
    {
        return _context.Customer
            .Skip(skip)
            .Take(take)
            .Select(
                customer => new CustomerViewModel
                {
                    // <assign properties here>
                }
            )
            .ToListAsync();
    }
