    public class Foo {
    
      public String Bar {
        get;
        set;
      }
    
      public String Baz {
        get;
        set;
      }
    
      public override Boolean Equals(Object other) {
        Foo otherFoo = other as Foo;
        if (otherFoo == null)
          return false;
        else
          return Bar.Equals(otherFoo.Bar) && Baz.Equals(otherFoo.Baz);
      }
      public override Int32 GetHashCode() {
        return Bar.GetHashCode() ^ Baz.GetHasCode();
      }
    }
