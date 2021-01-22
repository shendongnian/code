    EventPublisher publisher = new EventPublisher();
    foreach (EventInfo eventInfo in publisher.GetType().GetEvents())
    {
        DynamicEvent.Subscribe(eventInfo, publisher, (sender, e, eventName) =>
        {
            Console.WriteLine("Event raised: " + eventName);
        });
    }
