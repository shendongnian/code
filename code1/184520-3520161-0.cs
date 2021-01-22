    public class ArgumentNullOrEmptyException : ArgumentNullException
    {
        public ArgumentNullOrEmptyException( string paramName ) : base( paramName )
        {}
    
        public ArgumentNullOrEmptyException( string paramName, string message ) : base( paramName, message )
        {}
    
        public override string Message
        {
            get
            {
                return "Value cannot be null nor empty.{0}Parameter name: {1}".FormatWith( Environment.NewLine, ParamName );
            }
        }
    }
