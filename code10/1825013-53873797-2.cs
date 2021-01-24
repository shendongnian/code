    public EventDescriptor(Guid id, IEvent eventData)
     {
       AggregateId = id;
       EventData = eventData;
       if (!eventData.GetType().IsGenericType)
       {
           EventType = eventData.GetType().FullName;
       }
       else
       {
           // notice - this assumes we can take the FIRST generic argument, we don't check for others here
           EventType = eventData.GetType().GetGenericArguments().First().FullName;
       }
    }
