    DataTable customersTable = ...
    DataTable billingsTable = ...
    IEnumerable<Customer> customers = customersTable.ToCustomers();
    IEnumerable<Billing> billings = billingsTable.ToBillings();
    IEnumerable<CustomerBilling> customerBillings = customers.ToCustomerBillings(billing);
    DataTable customerBillingTable = result.ToDataTable();
 
