    class Base
    {
      public Base(string sMessage)
      {
         ConstructorStuff();
      }
      protected void ConstructorStuff()
      {
      }
    }
    
    class Derived : Base
    {
      public Derived(string someParams)
      {    
       string sMessage = "Blah " + someParams;
     
       ConstructorStuff();       
      }    
    }
