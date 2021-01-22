    class MyException : Exception {
        public MyException()
            : base("foo", new Exception("bar"))
        {
            ...
        }
    
        ...
    }
