    duplicateCustomers = duplicateCustomers.GroupBy(item => new 
    {
        CardNumber = item.CardNumber,
        CustomerNumber = item.CustomerNumber
    })
    .Select(item => new CustomerDTO()
    {
        CardNumber = item.Key.CardNumber,
        CustomerNumber = item.Key.CustomerNumber,
        FetchedDate = item.Max(m => m.FetchedDate)
    })
