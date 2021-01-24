     public static IEnumerable<CustomerBilling> LeftOuterJoinCustomerBilling(
        this IEnumerable<Customer> customers,
        IEnumerable<Billing> billings)
     {
          // call the LeftOuterJoin with the correct function to create a CustomerBilling, something like:
          return customers.LeftOuterJoin(billings,
        (customer, billing) => new CustomerBilling()
        {    // select the columns you want to use:
             CustomerId = customer.Id,
             CustomerName = customer.Name,
             ...
             BillingId = billing.Id,
             BillingTotal = billing.Total,
             ...
        });
