    // SharedAssembly.dll
    // marks ConsumingAssembly.dll as having access to internals...
    internal sealed class AccessToken { }
    public class SecuredClass
    {
       public static bool WorkMethod( AccessToken token, string otherParameter )
       {
           if( token == null )
               throw new ArgumentException(); // you may want a custom exception.
           // do your business logic...
           return true;        
       }
    }
    
    // ConsumingAssembly.dll  (has access via InternalsVisibleTo)
    public class MainClass
    {
      public static void Main()
      {
          var token = new AccessToken(); // can create this because of IVT access
          SecuredClass.WorkMethod( token, "" );  // tada...
      }
    }
