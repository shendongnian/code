    public class SampleEvent : IEvent
    {
    }
    public class SampleEventHandler : IEventHandler<SampleEvent>
    {
        public Task Handle(SampleEvent input) => Task.CompletedTask;
    }
