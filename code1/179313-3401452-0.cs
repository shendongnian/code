    using System; 
    class CApp
    {
        public static void Main()
        { 
            string s = "fred"; 
            long i = 10; 
            Console.WriteLine( "{0} is {1}an integer", s, (IsInteger(s) ? "" : "not ") ); 
            Console.WriteLine( "{0} is {1}an integer", i, (IsInteger(i) ? "" : "not ") ); 
        }
    
        static bool IsInteger( object obj )
        { 
            if( obj is int || obj is long )
                return true; 
            else 
                return false;
        }
    } 
