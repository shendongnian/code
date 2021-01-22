    class Exception
    {
         public Exception(string message)
         {
             [...]
         }
    }
    class MyExceptionClass : Exception
    {
         public MyExceptionClass(string message, string extraInfo)
         : base(message)
         {
             [...]
         }
    }
