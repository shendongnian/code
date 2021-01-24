    public class MyException : Exception
    {
        public MyException() { }
        public MyException(string message)
            : base(message)
        { }
    }
