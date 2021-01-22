    class Base
    {
      public Base(string sMessage)
      {
         //Do stuff
      }
    }
    
    class Derived : Base
    {
      public Derived(string someParams)
        : base("Blah " + someParams)
      {
      }
    
    }
