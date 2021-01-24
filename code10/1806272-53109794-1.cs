    class A
    {
      public virtual void Method1() { Console.WriteLine("A"); }
    }
    class B : A
    {
      override public void Method1() { Console.WriteLine("B"); }
      public void BaseMethod1() { base.Method1(); }
    }
