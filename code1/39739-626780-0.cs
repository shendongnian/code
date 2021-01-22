    class Base
    {
      protected void init() { }
      public Base(string sMessage)
      {
         init();
      }
    }
    class Derived : Base
    {
      public Derived(string someParams)
      {
       string sMessage = "Blah " + someParams;
       init();
      }
    }
