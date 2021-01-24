    public class X1 { }
    public class SomeClass
    {
      private static X1 _X = new X1();
      public X1 X 
      {
        get 
        {
          return _X;
        }
      }
    }
    var a = new SomeClass();
    var b = new SomeClass();
    Assert.That(a.X, Is.EqualTo(b.X)) // true, always
