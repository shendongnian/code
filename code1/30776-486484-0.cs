    [Serializable()]
    public class InvalidDepartmentException : System.Exception
    {
        public InvalidDepartmentException() { }
        public InvalidDepartmentException(string message) { }
        public InvalidDepartmentException(string message, System.Exception inner) { }
    
        // Constructor needed for serialization 
        // when exception propagates from a remoting server to the client.
        protected InvalidDepartmentException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
