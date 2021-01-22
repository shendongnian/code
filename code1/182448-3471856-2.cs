    public abstract class MyAppCustomException : System.Exception
    {
        internal MyAppCustomException(string message)
            : base(message)
        {
        }
    
        internal MyAppCustomException(string message, System.Exception innerException)
            : base(message,innerException)
        {            
        }
    }
    
    public class AppNotFoundCustomException : MyAppCustomException
    {
        public AppNotFoundCustomException(): base("Could not find app")
        {
        }
    }
