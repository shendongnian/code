     [Serializable]
     public class TestException: ApplicationException
     {
         public TestException(string Message, 
                      Exception innerException): base(Message,innerException) {}
         public TestException(string Message) : base(Message) {}
         public TestException() {}
         #region Serializeable Code
         public TestException(SerializationInfo info, 
               StreamingContext context): base(info, context) { }
         #endregion Serializeable Code
     }
