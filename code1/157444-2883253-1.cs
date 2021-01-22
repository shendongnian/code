    public class Foo2: Foo {     
      public int DoubleValue { 
        get {
          lock( ThisLock ) {
            return base.Value * 2;
          }
        }
        set {
          lock( ThisLock ) {
            base.Value = value / 2;
          }
        }
      }
    }
