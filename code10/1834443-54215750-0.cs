      class Main {
        static double MultiplyBy2(double x)
        {
            return 2 * x;
        }
    
        static void Main(String[] args)
        {
            int x = 5;
    
            Console.WriteLine( MultiplyBy2( 6 ) );     // 12
            Console.WriteLine( MultiplyBy2( x ) );     // 10
        }
      }
