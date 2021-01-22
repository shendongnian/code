    class Base
    {
      public Base(string sMessage)
      {
         ConstructorStuff();
      }
      protected Base()
      {
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
