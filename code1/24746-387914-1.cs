// Next, you'd have to tell LinFu to automatically register your product class:
[Factory(typeof(Product))]
public class ProductFactory : IFactory
{
     object CreateInstance(IServiceRequest request)
     {
          // Grab a copy of the IRepository<Product> from the container
          var repository = container.GetService<IRepository<Product>>();
          
          // Get the id (this assumes that your id is an Int32)
          var id = (int)request.Arguments[0];
          
          // Return the product itself
          return repository.GetById(id);
     }
}
// Do the same thing with the Client class
// (Note: I did a simple cut and paste to keep things simple--please forgive the duplication)
[Factory(typeof(Client))]
public class ClientFactory : IFactory
{
     object CreateInstance(IServiceRequest request)
     {
          // Grab a copy of the IRepository<Client> from the container
          var repository = container.GetService<IRepository<Product>>();
          
          // Get the id (this assumes that your id is an Int32)
          var id = (int)request.Arguments[0];
          
          // Return the client itself
          return repository.GetById(id);
     }
}
[Factory(typeof(Transaction))]
public class TransactionFactory : IFactory
{
     object CreateInstance(IServiceRequest request)
     {
        // Note: Argument checking has been removed for brevity
        var container = request.Container;
        var arguments = request.Arguments;
        var productId = (int)arguments[0];
        var clientId = (int)arguments[1];
        // Get the product and the client
        var product = container.GetService<Product>(productId);
        var client = container.GetService<Client>(clientId);
        
        // Create the transaction itself
        return new Transaction(product, client);
     }
}
// Make this implementation a singleton
[Implements(typeof(MarginCalculator), LifecycleType.Singleton)]
public class ConcreteMarginCalculatorA : MarginCalculator
{
    public override double CalculateMargin()
    {
        // Perform actual calculation
    }
}
