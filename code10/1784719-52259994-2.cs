    private static void RegisterConsumers(Container container)
        {
            container.Register<IEventPublisher, EventPublisher>(Lifestyle.Scoped);
            container.Collection.Register(typeof(IConsumer<>), new[] {
                typeof(CommonConsumer),
                typeof(MeasurementEventConsumer),
                typeof(PartRepairEventConsumer),
                typeof(OrderItemEventConsumer),
                typeof(OrderTaskEventConsumer),
                typeof(OrderItemWorkStatusEventConsumer),
                typeof(OrderItemTaskEventConsumer),
                typeof(OrderTaxEventConsumer)
           });
        }
