    [Serializable]
    public class MyException : AppliationException
    {
        // Optional Constructors
        // Make sure you include this so your Excpetion is properly Serializable
        protected MyException(SerializationInfo info, StreamingContext ctxt) 
            : base(info, ctxt)
        { }
    }
