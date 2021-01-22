    AsyncEventPublisher publisher = new AsyncEventPublisher();
    Action action = () =>
    {
        publisher.RaiseA();
        publisher.RaiseB();
        publisher.RaiseC();
    };
    var expectedSequence = new[] { "EventA", "EventB", "EventC" };
    using (var monitor = new EventMonitor(publisher, TimeoutMS, expectedSequence))
    {
        monitor.StartTest(action);
    }
