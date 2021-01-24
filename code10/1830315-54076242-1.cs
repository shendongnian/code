    using (var dbContext = new MyDbContext(...))
    {
         const int pageSize = 100
         IEnumerable<ICollection<Customer>> customerPages = dbContext.Customers.ToPages(pageSize);
         // note: nothing has been enumerated yet, no data has been fetched
         foreach (var customerPage in customerPages)
         {
             // one page has been fetched, we can do something with the Customers in the page
            foreach (Customer customer in customerPage)
            {
                ProcessCustomer(customer);
                bool continueProcessingCustomers = ...;
                if (!continueProcessingCustomers) return;
                // so if you break in page 3, the other pages are not fetched!
            }
        }
    }
