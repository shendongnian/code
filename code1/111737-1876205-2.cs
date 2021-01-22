    public class Foo {
      public virtual int MyField = 1; // Nope, this can't
      public virtual int Bar {get; set; }
    }
    public class MyDerive : Foo {
      public override MyField; // Nope, this can't
      public override int Bar {
        get {
          //do something;
        }
        set; }
    }
