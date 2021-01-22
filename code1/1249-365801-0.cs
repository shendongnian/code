    class ClassA 
    {
      public ClassA(int a)
      {
        //Do something
      }
      public void Method1()
      {
         //Do Something
      }
    }
    
    class ClassB : ClassA
    {
      public ClassB(int a) : base(a) // calling the base class constructor
      {
        //Do something
      }
      public void Method2()
      {
        base.Method1();               // calling the base class method
      }
    }
