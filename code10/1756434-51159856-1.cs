    using static System.Console;
    
    public struct Cell
    {
        public double[] column;    // reference to a double array
    }
    
    class Program {
    
        static void Main() {
    
            Cell[] pmat;  // reference to a Cell array
    
            pmat = new Cell[ 2 ];  // allocates an array of Cell objects
    
            pmat[ 0 ].column = new double[ 3 ];
            pmat[ 1 ].column = new double[ 4 ];
    
            pmat[ 0 ].column[ 1 ] = 777.0;
            pmat[ 1 ].column[ 2 ] = 888.0;
    
            foreach( var x in pmat[ 0 ].column ) WriteLine( x );  // 0 777 0
            foreach( var x in pmat[ 1 ].column ) WriteLine( x );  // 0 0 888 0
        }
    }
