    using static System.Console;
    
    class Program {
    
        static void Main() {
    
            double[][] pmat;            // reference to a jagged array
            pmat = new double[ 2 ][ ];  // creates a jagged array of size 2
    
            pmat[ 0 ] = new double[ 3 ];
            pmat[ 1 ] = new double[ 4 ];
    
            pmat[ 0 ][ 1 ] = 777.0;
            pmat[ 1 ][ 2 ] = 888.0;
    
            foreach( var x in pmat[ 0 ] ) WriteLine( x );  // prints 0 777 0
            foreach( var x in pmat[ 1 ] ) WriteLine( x );  // prints 0 0 888 0
        }
    }
