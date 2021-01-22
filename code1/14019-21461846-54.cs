    public class CustomerService
    {
        [RetryOnException(MaxRetries = 5)]
        public void Save(Customer customer)
        {
            // Database or web-service call.
        }
    }
