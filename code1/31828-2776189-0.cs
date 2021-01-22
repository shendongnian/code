    public class A
    {
      public A(int a, int b)
      {
        DoSomething(int a, int b);
      }
    
      virtual public void DoSomething(int a, int b)
      {
         
      }
    }
    
    public class B : A
    {
      override public void DoSomething(int a, int b)
      {
        //class specific stuff
      }
    }
