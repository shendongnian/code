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
            switch(value)
            {
                case 0: return Success;
                case 1: return FailReason1;
                case 2: return FailReason2;
            }
            throw new ArgumentException( "Value fails to meet the constraint defined for " + typeof(ReturnValue).FullName + ".", "value" );
        }
    }
