    class A
    {
      private int a = 1;
    
      void A()
      {
        int a = 2;
    
        Console.WriteLine(a); // 2
        Console.WriteLine(this.a); // 1
      }
    }
