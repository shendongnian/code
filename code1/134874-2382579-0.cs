    public class MyCustomException : Exception  // Or you could derive from ApplicationException
    {
       public MyCustomException(string msg, Exception innerException)
       : base(msg, innerException)
       {
       }
    }
