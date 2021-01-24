    var builder = new ContainerBuilder();
    builder
        .RegisterEventStore(
            ctx =>
            {
                var eventStoreOptions =
                    new EventStoreOptions
                    {
                        ConnectionString = "ConnectTo=tcp://admin:changeit@127.0.0.1:1113; HeartBeatTimeout=500";
                    };
                return eventStoreOptions;
            },
            ctx =>
            {
                var customDomainEventMappersOptions =
                    new CustomDomainEventMappersOptions()
                        .UsesCustomMappers<FakeDomainEventNotSerializable, FakeSerializableEvent>(
                            domainEvent =>
                            {
                                var mapper =
                                    new FakeDomainEventNotSerializableToFakeSerializableEventMapper();
                                var result = mapper.Map(domainEvent);
                                return result;
                            },
                            serializableEvent =>
                            {
                                var mapper =
                                    new FakeSerializableEventToFakeDomainEventNotSerializableMapper();
                                var result = mapper.Map(serializableEvent);
                                return result;
                            });
                return customDomainEventMappersOptions;
            });
    
    var container = builder.Build();
