    class Base
    {
        public Base( string sMessage )
        {
            // Do stuff
        }
    }
    class Derived : Base
    {
        public Derived( string sMessage ) : base( AdjustParams( sMessage ) )
        {
        }
        static string AdjustParams( string sMessage )
        {
            return "Blah " + sMessage;
        }
    }
