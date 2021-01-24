    public static IEnumerable<Customer> ToCustomers(this DataTable table)
    {
        ... // TODO: implement
    }
    public static IEnumerable<Billing> ToBillings(this DataTable table)
    {
        ... // TODO: implement
    }
   
    public static DataTable ToDataTable(this IEnumerable<Customer> customers) {...}
    public static DataTable ToDataTable(this IEnumerable<Billing> billings) {...}
