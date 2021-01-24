    private static IEnumerable<ICollection<Customer>> ToPages(
        this IQueryable<Customer> customers, int pageSize)
    {
        int lastFetchedCustomerId = 0; // no primary key fetched yet
        // get the first page:
        var page = customers.Where(customer => customer.Id > lastFetchedCustomerId)
            .Take(pageSize)
            .ToList();
        // as long as there is a Customer in the page, return the page
        while (page.Count != 0)
        {   // there are customers
            yield return page;
            lastFetchedCustomerId = page[page.Count-1].Id;
            page = customers.Where(customer => customer.Id > lastFetchedCustomerId)
                .Take(pageSize)
                .ToList();
        }
    }
