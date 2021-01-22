    public class MyException : Exception
    {
        public MyException() { }
        public MyException(string msg) : base(msg) { }
        public MyException(string msg, Exception inner) : base(msg, inner) { }
    }
