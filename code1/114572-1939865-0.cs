    [Serializable]
    public class MyCustomException : Exception
    {
        public MyCustomException(string myMessage)
        {
        	MyMessage = myMessage;
        }
	    protected MyCustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
	    {
	    }
	    public string MyMessage { get; private set; }
    }
    //...
    
    throw new MyCustomException("Hello, world!");
