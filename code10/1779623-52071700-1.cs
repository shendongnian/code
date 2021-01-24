    static Task<List<Address>> FetchAddresses (this IQueryable<Customer> customers)
    {
         var query = customers.FetchAddresses;   // no query executed yet
         return await query.ToListAsync();       // execute the query
         // could of course be done in one statement
    }
    static Task<Address> FetchAddress(this.IQueryable<Customer> customers, int customerId)
    {
        var query = customers.Where(customer => customer.Id == customerId)
                             .FetchAddresses();
        // no query executed yet!
        // execute:
        return await query.FirstOrDefaultAsync();
    }
