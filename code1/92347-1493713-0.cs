    [Fact]
    public void PurgeOrder_should_log_action()
    {
        var order = new Order();
        var logger = Isolate.Fake.Instance<IOrderLogger>();    
        var logAction = Isolate.Fake.Instance<LogAction>();
        Isolate.Swap.NextInstance<LogAction>().With(logAction);
        
        var service = new OrderService(logger);
        service.PurgeOrder(order);
        
        Isolate.Verify.WasCalledWithExactArguments(() => logger.Action(logAction));
    }
        
