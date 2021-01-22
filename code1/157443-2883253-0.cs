    public class Foo {
      private readonly object thisLock = new object();
      private int ivalue;
    
      protected object ThisLock {
        get {
          return thisLock;
        }
      }
    
      public int Value { 
        get {
          lock( ThisLock ) {
            return ivalue;
          }
        }
        set {
          lock( ThisLock ) {
            ivalue= value;
          }
        }
      }
    }
