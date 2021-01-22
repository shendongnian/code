    class A
    {
      void protoX() { Console.WriteLine("x"); }
      virtual void X() { protoX(); }
    }
    
    class B : A
    {
      override void X() { Console.WriteLine("y"); }
    }
    
    class Program
    {
      static void Main()
      {
        A b = new B();
        // Call A.X somehow, not B.X...
        b.protoX();
      }
