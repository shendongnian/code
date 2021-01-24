    var query = dbContext.Customers                 // GroupJoin customers and Transactions
        .GroupJoin(dbContext.Transactions,
        customer => customer.Id,                    // from each Customer take the primary key
        transaction => transaction.CustomerId,      // from each Transaction take the foreign key
        (customer, transactions) => new             // take the customer with his matching transactions
        {                                           // to make a new:
           Id = customer.Id,
           Created = customer.Created,
           ...
           LatestTransactions = transactions
               .OrderBy(transaction => transaction.Created)
               .Select(transaction => new
               {
                   Id = transaction.Id,
                   Created = transaction.Created,
                   ...
               })
               .Take(10)
               .ToList(),
           })
           .Take(10);
