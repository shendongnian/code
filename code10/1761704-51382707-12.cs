    public class CustomerService
    {
        private readonly SupplyApiClientHttpSettings settings;
        public CustomerService(IOptionsSnapshot<SupplyApiClientHttpSettings> options)
        {
            this.settings = options.Value;
        }
        public Customer GetCustomer()
        {
            return new Customer
            {
                SomeValue = settings.SomeValue
            };
        }
    }
