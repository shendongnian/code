    public class FluentPerson<T>
        where T : FluentPerson<T>
    {
        public T WithFirstName(string firstName)
        {
            // ...
            return (T)this;
        }
        public T WithLastName(string lastName)
        {
            // ...
            return (T)this;
        }
    }
    public class FluentCustomer : FluentPerson<FluentCustomer>
    {
        public FluentCustomer WithAccountNumber(string accountNumber)
        {
            // ...
            return this;
        }
    }
