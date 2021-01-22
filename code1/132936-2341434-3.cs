    public class ProductionTraceListener : DefaultTraceListener
    {
        public override void Fail(string message, string detailMessage)
        {
            string failMessage = message;
    
            if (detailMessage != null)
            {
                failMessage += " " + detailMessage;
            }
    
            throw new AssertionFailedException(failMessage);
        }
    }
    [Serializable]
    public class AssertionFailedException : Exception
    {
        public AssertionFailedException() { }
        public AssertionFailedException(string message) : base(message) { }
        public AssertionFailedException(string message, Exception inner) 
            : base(message, inner) { }
        protected AssertionFailedException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
    
