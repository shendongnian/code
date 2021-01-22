    public static class DynamicHelper
    {
        private static void Test( )
        {
            dynamic myobj = new
                            {
                                myInt = 1,
                                myArray = new[ ]
                                          {
                                              1, 2.3
                                          },
                                myDict = new
                                         {
                                             myInt = 1
                                         }
                            };
            var myIntOrZero = myobj.GetAsOrDefault< int >( ( Func< int > )( ( ) => myobj.noExist ) );
            int? myNullableInt = GetAs< int >( myobj, ( Func< int > )( ( ) => myobj.myInt ) );
            if( default( int ) != myIntOrZero )
                Console.WriteLine( $"myInt: '{myIntOrZero}'" );
            if( default( int? ) != myNullableInt )
                Console.WriteLine( $"myInt: '{myNullableInt}'" );
            if( DoesPropertyExist( myobj, "myInt" ) )
                Console.WriteLine( $"myInt exists and it is: '{( int )myobj.myInt}'" );
        }
        public static bool DoesPropertyExist( dynamic dyn, string property )
        {
            var t = ( Type )dyn.GetType( );
            var props = t.GetProperties( );
            return props.Any( p => p.Name.Equals( property ) );
        }
        public static object GetAs< T >( dynamic obj, Func< T > lookup )
        {
            try
            {
                var val = lookup( );
                return ( T )val;
            }
            catch( RuntimeBinderException ) { }
            return null;
        }
        public static T GetAsOrDefault< T >( this object obj, Func< T > test )
        {
            try
            {
                var val = test( );
                return ( T )val;
            }
            catch( RuntimeBinderException ) { }
            return default( T );
        }
    }
