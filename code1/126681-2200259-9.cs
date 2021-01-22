    using System;
    using System.Runtime.Serialization;
    [Serializable]
    public class MyException : Exception
    {
        // Constructors
        public MyException(string message) 
            : base(message) 
        { }
        // Ensure Exception is Serializable
        protected MyException(SerializationInfo info, StreamingContext ctxt) 
            : base(info, ctxt)
        { }
    }
