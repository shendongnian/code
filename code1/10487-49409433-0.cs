    public static class ReinterpretCastExtensions {
       public static unsafe float AsFloat( this int n ) => *(float*)&n;
       public static unsafe int AsInt( this float n ) => *(int*)&n;
    }
    
    public static class MainClass {
       public static void Main( string[] args ) {
          Console.WriteLine( 1.0f.AsInt() );
          Console.WriteLine( 1.AsFloat() );
       }
    }
