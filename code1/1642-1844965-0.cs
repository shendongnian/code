    public class MyExceptionClass : Exception
    {
        public MyExceptionClass(string message,
          Exception innerException): base(message, innerException)
        {
            //other stuff here
        }
    }
