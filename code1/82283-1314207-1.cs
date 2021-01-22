    void Main()
    {
       DoIt d1 = Doer.DoThatThang;
       DoIt d2 = Doer.DoThatThang;
       
       IAsyncResult r1 = d1.BeginInvoke( 5, null, null );
       IAsyncResult r2 = d2.BeginInvoke( 10, null, null );
       
       Thread.Sleep( 1000 );
       
       var s1 = d1.EndInvoke( r1 );
       var s2 = d2.EndInvoke( r2 );
       
       s1.Dump(); // You told me 5
       s2.Dump(); // You told me 10
    }
    
    public delegate string DoIt( int x );
    
    public class Doer
    {
      public static string DoThatThang( int x  )
      {
        return "You told me " + x.ToString();
      }
    }
