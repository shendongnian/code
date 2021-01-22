          public class VC
          {
             virtual public int f() { return 2; }
             virtual public int Count { get { return 200; } }
    
          }
    
          public class C
          {
             //[MethodImpl( MethodImplOptions.NoInlining)]
              public int f() { return 2; }
              public int Count { get { return 200; } }
    
          }
