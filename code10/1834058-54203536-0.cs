    var bus = BusConfigurator.ConfigureBus((h,cfg) =>
    {
         h.ConfigurePublish(x =>
            x.UseExecute<PublishContext<TestMessage>>(p => 
            { 
                  p.Headers.Set("x-deduplication-header", p.Message.Day.Ticks);
            }));
    });
