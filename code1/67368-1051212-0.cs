    public class Foo { 
      [Something]
      public int Field1;
      
      public Foo() {
        FieldInfo fi = typeof(Foo).GetField("Field1");
        SomethingAttribute si = (SomethingAttribute)fi.GetCustomAttribute(typeof(SomethingAttribute),false)[0];
        // grab any Custom attribute off of Fiield1 here
      }
    }
