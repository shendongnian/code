    public class MyCustomException : Exception
    {
        public MyCustomException() : base() { }
        public MyCustomException(string message) : base(message) { }
        public MyCustomException(string message, Exception innerException) : base(message, innerException) { }
        // and so on...
    }
