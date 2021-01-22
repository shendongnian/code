    public class Customer: IDoSomeStaticMath
    {
      //create new customer
      public Customer(Transaction t) { ... }
    
      //open existing customer
      public Customer(Transaction t, int id) { ... }
    
      //dummy instance
      public Customer() { IsDummy = true; }
    
      int DoSomeStaticMath(int a) { }
    
      void SomeOtherMethod() 
      { 
        if(!IsDummy) 
        {
          //do work...
        }
      }
    }
