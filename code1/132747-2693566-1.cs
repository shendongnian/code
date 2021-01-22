    AsyncEventPublisher publisher = new AsyncEventPublisher();
    Action test = () =>
    {
        publisher.RaiseA();
        publisher.RaiseB();
        publisher.RaiseC();
    };
    var expectedSequence = new[] { "EventA", "EventB", "EventC" };
    EventMonitor.Assert(test, publisher, expectedSequence, TimeoutMS);
