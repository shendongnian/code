    var query = dbContext.Customers                           // from the collection of Customer
        .OrderByDescending(customer => customer.Created)      // order this by descending Creation date
        .Select(customer => new                               // from every Customer select the
        {                                                     // following properties
             // select only the properties you actually plan to use
             Id = Customer.Id,
             Created = Customer.Created,
             Name = Customer.Name,
             ...
             LatestTransactions = customer.Transactions        // Order the customer's collection
                 .OrderBy(transaction => transaction.Created)  // of Transactions
                 .Select(transaction => new                    // and select the properties
                 {
                     // again: select only the properties you plan to use
                     Id = transaction.Id,
                     Created = transaction.Created,
                     ...
                     // not needed you know it equals Customer.Id
                     // CustomerId = transaction.CustomerId,
                 })
                 .Take(10)                                      // take only the first 10 Transactions
                 .ToList(),
        })
        .Take(10);                                              // take only the first 10 Customers
 
