    class A
    {
      public void Method1() { Console.WriteLine("A"); }
    }
    class B : A
    {
      new public void Method1() { Console.WriteLine("B"); }
      public void BaseMethod1() { base.Method1(); }
    }
