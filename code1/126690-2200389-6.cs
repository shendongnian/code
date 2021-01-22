    [Serializable]
    public class MyException : Exception
    {
        public MyException ()
        {}
    
        public MyException (string message) 
            : base(message)
        {}
        
        public MyException (string message, Exception innerException)
            : base (message, innerException)
        {}    
    }
