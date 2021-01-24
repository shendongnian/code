    public enum ExceptionCode
    {
        IncorrectUser = 1001,
        InvalidPassword= 1002,
        RanOutOfBeer = 9999,
    }
    public enum Severity
    {
        Warning,
        Error
    }
    public class TechnicalException : Exception
    {
        public ExceptionCode ErrorCode
        {
            get;
        }
        public Severity ErrorSeverity
        {
            get;
        }
        public TechnicalException(ExceptionCode errorCode, string errorDescription) : base(errorDescription)
        {
            ErrorCode = errorCode;
            ErrorSeverity = Severity.Error;
        }
    }
    public class InvalidUserException : TechnicalException
    {
        public InvalidUserException(string username, string password) 
            : base(ExceptionCode.IncorrectUser, $"User {username} with password {password} is invalid")
        {
        }
    }
    public class test
    {
        public void throwit()
        {
            throw new InvalidUserException("bob", "abc123");
        }
    }
