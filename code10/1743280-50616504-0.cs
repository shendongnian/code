    public interface IMessage
    {
    };
    
    public interface IComponent
    {
        // Returns a Type object for the message that this component will handle.
    	Type MessageType { get; }
        // The message handler itself.
    	void HandleMessage(IMessage message);
    }
