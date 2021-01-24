    var bus = BusConfigurator.ConfigureBus((h,cfg) =>
    {
        h.ConfigurePublish(pc => pc.AddPipeSpecification(
            new DelegatePipeSpecification<PublishContext<TestMessage>>(p =>
            {
                p.Headers.Set("x-deduplication-header", p.Message.Day.Ticks);
            })));
    });
