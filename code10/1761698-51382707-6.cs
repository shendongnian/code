    public class CustomerService
    {
        private readonly SupplyApiClientHttpSettings settings;
        public CustomerService(IOptionsSnapshot<SupplyApiClientHttpSettings> settings)
        {
            this.settings = settings.Value;
        }
        public Customer GetCustomer()
        {
            return new Customer
            {
                SomeValue = settings.SomeValue
            };
        }
    }
