    public class TestClass {
      public virtual void int SomeFunction( string /*str*/ )
      {
        return 0;
      }
      public void TestFun()
      {
        SomeFunction( "" );
      }
    }
    public class TestClassTracer : TestClass {
      public override void int SomeFunction( string str )
      {
        // do something
        return base.SomeFunction( str );
      }
    }
    
          
