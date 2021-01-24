    public class SecurityTokenRevokedException : SecurityTokenException
    {
        public SecurityTokenRevokedException()
        {
        }
    
        public SecurityTokenRevokedException(string message) : base(message)
        {
        }
    
        public SecurityTokenRevokedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
