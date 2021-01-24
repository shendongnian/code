    public class ExampleComponent : IComponent
    {
    	public class ExampleMessage : IMessage
    	{
            // ..data goes here
    	};
    
    	public Type MessageType { get { return typeof(ExampleMessage); } }
    	public void HandleMessage(IMessage message)
    	{
    		var exampleMessage = (ExampleMessage)message;
    		Console.WriteLine("Handling message of type ExampleMessage");
    	}
    }
