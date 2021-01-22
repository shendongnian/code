    public class Program {
        static void SWAP<T>( ref T a, ref T b ) {
          T dum = a;
          a = b;
          b = dum;
        }
    
        static void Main( string[] args ) {
          double a = 1; double b = 2;
          SWAP<double>( ref a,ref  b );
    
          Console.Write( a.ToString() );
    
          Console.Read();
        }
      }
