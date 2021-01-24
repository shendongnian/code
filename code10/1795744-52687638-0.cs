    public override void Post(SendOrPostCallback d, object state)
    {
        base.Post(state2 => {
            // here we make the continuation run on the original context
            SetSynchronizationContext(this); 
            d(state2);
        }, state);        
        Console.WriteLine("Posted");
    }
