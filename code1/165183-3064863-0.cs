    public abstract class Base
    { 
      public delegate void logEvent(String message, int level); 
 
      public event logEvent log; 
      protected void RaiseLogEvent( string msg, int level )
      {
          // note the idomatic use of the copy/test/invoke pattern...
          logEvent evt = log;
          if( evt != null )
          {
              evt( msg, level );
          }
      }
    } 
