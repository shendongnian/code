    public sealed class OperationError
    {
        public bool IsError { get; private set; }
        public string ErrorMessage { get; private set; }
        public static implicit operator bool( OperationError err )
        { 
            return IsError;
        }
        // returned to indicate success
        public static readonly OperationError Success = 
             new OperationError();
        private OperationError() {}
        public OperationError( string errorMessage )
        {
            ErrorMessage = errorMessage ?? "Unknown error";           
        }
    }
    // here's a case that demonstrates the usage:
    public OperationError SomeMethod()
    {
        if( someError() )
           return new OperationError( "someError failed, oops!" );
        return OperationError.Success; // all is well...
    }
    // somewhere else in your code...
    var result = SomeMethod();
    if( result.IsError )
        Console.WriteLine( result.ErrorMessage );
    // alternatively...use the implicit bool conversion...
    if( !SomeMethod() )
        throw new ApplicationException( "Oh no!" );
