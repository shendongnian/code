    public sealed class ReturnValue: ConstrainedNumber<int>
    {
        public static readonly NumberConstraint<int> constraint = (int x) => (x >= 0 && x < 3);
    
        public static readonly ReturnValue Success = new ReturnValue(0);
        public static readonly ReturnValue FailReason1 = new ReturnValue(1);
        public static readonly ReturnValue FailReason2 = new ReturnValue(2);
    
        private ReturnValue( int value ): base( value, constraint ) {}
        private ReturnValue( ReturnValue original ): base (original) {} //may be used to support IClonable implementation in base class
        public static explicit operator ReturnValue( int value )
        {
            switch(value) //switching to return an existing instance is more efficient than creating a new one and re-checking the constraint when there is a limited number of allowed values; if the constraint was more generic, such as an even number, then you would instead return a new instance here, and make your constructors public.
            {
                case 0: return Success;
                case 1: return FailReason1;
                case 2: return FailReason2;
            }
            throw new ArgumentException( "Value fails to meet the constraint defined for " + typeof(ReturnValue).FullName + ".", "value" );
        }
    }
