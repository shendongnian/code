    public class Person
    {
        public string FirstName { get; set; }
        public string LastName {get; set;}
        public override string ToString()
        {
            return $"First name: {FirstName} last name: {LastName}";
        }
    }
    public class Customer : Person
    {
        public string AccountNumber { get; set; }
        public long Id { get; set; }
        public override string ToString()
        {
            return base.ToString() + $" account number: {AccountNumber} id: {Id}");
        }
    }
**A class that adds some fluent mechanism**
    public class FluentCustomer 
    {
        private Customer Customer { get; }
        public FluentCustomer() : this(new Customer())
        {
        }
        private FluentCustomer(Customer customer)
        {
            Customer = customer;
        }
        public FluentCustomer WithAccountNumber(string accountNumber)
        {
            Customer.AccountNumber = accountNumber;
            return this;
        }
        public FluentCustomer WithId(long id)
        {
            Customer.Id = id;
            return this;
        }
        public FluentCustomer WithFirstName(string firstName)
        {
            Customer.FirstName = firstName;
            return this;
        }
        public FluentCustomer WithLastName(string lastName)
        {
            Customer.LastName = lastName;
            return this;
        }
        public static implicit operator Customer(FluentCustomer fc)
        {
            return fc.Customer;
        }
        public static implicit operator FluentCustomer(Customer customer)
        {
            return new FluentCustomer(customer);
        }
    }
**An extension method to switch to fluent mode**
    public static class CustomerExtensions 
    {
        public static FluentCustomer Fluent(this Customer customer)
        {
            return customer;
        }
    }
**The same example as in question**
        Customer customer = new Customer().Fluent()
                            .WithAccountNumber("000")
                            .WithFirstName("John")
                            .WithLastName("Smith")
                            .WithId(123);
