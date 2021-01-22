    class Customer
    {
        private Customer(...) { ... }
        private static ICustomerFactory GetCustomerFactory()
        {
            return new CustomerFactory();
        }
        private class CustomerFactory : ICustomerFactory
        {
            Customer CreateCustomer(...) { return new Customer(...); }
        }
    }
    public interface ICustomerFactory
    {
        Customer CreateCustomer(...);
    }
