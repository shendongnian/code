    IEventAggregator ev;
    ev.Publish<MyCustomMessage>();
            
    //or
            
    ev.Publish(new MyCustomMessage(someData));
        
    //and similarly subscription
        
    ev.Subscribe<MyCustomMessage(this.OnCustomMessageReceived);
        
    // ... 
        
    private void OnCustomMessageReceived(MyCustomMessage message)
    {
       // ...
    }
    
    // With a BaseMessageEvent class as follows (see the blog post above for where this comes from)
    
    /// <summary>
    /// Base class for all messages (events) 
    /// </summary>
    /// <typeparam name="TMessage">The message type (payload delivered to subscribers)</typeparam>
    public class BaseEventMessage<TMessage> : CompositePresentationEvent<TMessage>
    {
    }
