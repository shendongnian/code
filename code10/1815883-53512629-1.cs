    private static void Main()
    {
        object handler = new TestIntegrationEventHandler();
        Type eventType = typeof(TestIntegrationEvent);
        Type concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);
        Console.WriteLine(concreteType.IsInstanceOfType(handler));
        Console.ReadLine();
    }
