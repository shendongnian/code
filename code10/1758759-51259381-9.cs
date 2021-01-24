    public IQueryable<CustomerInfo> CustomerInfoAsQueryable()
    {
        return _dbCustomerService.Info("CustomerID123")
                                 .Select(ci =>
                                 {
                                     ci.SetLoadLogbook(path => GetLogbookContent(path));
                                     return ci;
                                 });
    }
