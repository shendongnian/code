    public static IEnumerable<TResult> LeftOuterJoin<TResult>(
        this IEnumerable<Customer> customers,
        IEnumerable<Billing> billings,
        Func<Customer, Billing, TResult> resultSelector)
    {
        return customers.LeftOuterJoin(billings,  // left outer join Customer and Billings
           customer => customer.RespId,           // from every Customer take the foreign key
           billing => billing.Id                  // from every Billing take the primary key
           // from every customer with matching (or default) billings
           // create one result:
           (customer, billing) => resultSelector(customer, billing));                                
    }
