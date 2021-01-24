    using SimpleInjector;
    static class Program
    {
    static readonly Container container;
    static Program() {
        // 1. Create a new Simple Injector container
        container = new Container();
        // 2. Configure the container (register)
        container.Register<IOrderRepository, SqlOrderRepository>();
        container.Register<ILogger, FileLogger>(Lifestyle.Singleton);
        container.Register<CancelOrderHandler>();
        // 3. Verify your configuration
        container.Verify();
    }
    static void Main(string[] args)) {
        // 4. Use the container
        var handler = container.GetInstance<CancelOrderHandler>();
        var orderId = Guid.Parse(args[0]);
        var command = new CancelOrder { OrderId = orderId };
        handler.Handle(command);
    }
    }
