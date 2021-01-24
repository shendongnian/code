    public static void Subscribe<TMessage>(Action<TMessage> action) 
        where TMessage : IMessage
    {
        subActions.Add(typeof(TMessage), (x) => { action((TMessage)x); });
    }
