    public class CancelOrderHandler {
    private readonly IOrderRepository repository;
    private readonly ILogger logger;
    private readonly IEventPublisher publisher;
    // Use constructor injection for the dependencies
    public CancelOrderHandler(
        IOrderRepository repository, ILogger logger, IEventPublisher publisher) {
        this.repository = repository;
        this.logger = logger;
        this.publisher = publisher;
    }
    public void Handle(CancelOrder command) {
        this.logger.Log("Cancelling order " + command.OrderId);
        var order = this.repository.GetById(command.OrderId);
        order.Status = OrderStatus.Cancelled;
        this.repository.Save(order);
        this.publisher.Publish(new OrderCancelled(command.OrderId));
    }
    }
    public class SqlOrderRepository : IOrderRepository {
    private readonly ILogger logger;
    // Use constructor injection for the dependencies
    public SqlOrderRepository(ILogger logger) {
        this.logger = logger;
    }
    public Order GetById(Guid id) {
        this.logger.Log("Getting Order " + order.Id);
        // Retrieve from db.
    }
    public void Save(Order order) {
        this.logger.Log("Saving order " + order.Id);
        // Save to db.
    }
    }
