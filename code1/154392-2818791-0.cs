    public static void WireEvents(object subject)
    {
        Type type = subject.GetType();
    
        var events = type.GetEvents()
            .Where(item => item.EventHandlerType == typeof(InvalidDomainObjectEventHandler));
        foreach (EventInfo info in events)
            info.AddEventHandler(subject, new InvalidDomainObjectEventHandler(HandleDomainObjectEvent));
    }
