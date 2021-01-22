        [Serializable()]
        public sealed class MyException : Exception
        {
          public MyException()
          {
             // Add any type-specific logic, and supply the default message.
          }
    
          public MyException(string message): base(message) 
          {
             // Add any type-specific logic.
          }
          public MyException(string message, Exception innerException): 
             base (message, innerException)
          {
             // Add any type-specific logic for inner exceptions.
          }
          private MyException(SerializationInfo info, 
             StreamingContext context) : base(info, context)
          {
             // Implement type-specific serialization constructor logic.
          }
        }  
