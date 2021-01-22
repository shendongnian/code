    public class AppRegistry : Registry
    {
      public AppRegistry()
      {
        ForRequestedType<ICheckoutService>().TheDefaultIsConcreteType<CheckoutService>();
        ForRequestedType<ICustomerRepository>().TheDefaultIsConcreteType<CustomerRepository>();
        // etc...
      }
    }
