    using static System.Console;
    
    public class Cell
    {
        public double[] column;
    }
    
    class Program {
    
        static void Main() {
    
            Cell[] pmat;
    
            pmat = new Cell[ 2 ];  // allocates an array of references (to Cell objects)
    
            pmat[ 0 ] = new Cell();  // allocates a new object
            pmat[ 1 ] = pmat[ 0 ];   // can point to an existing object
    
            pmat[ 0 ].column = new double[ 3 ];
    
            pmat[ 0 ].column[ 1 ] = 777.0;
            pmat[ 1 ].column[ 2 ] = 888.0;  // modifies pmat[0] in practice
    
            foreach( var x in pmat[ 0 ].column ) WriteLine( x );  // 0 777 888
            foreach( var x in pmat[ 1 ].column ) WriteLine( x );  // 0 777 888
        }
    }
