    namespace Demo
    {
        class A 
        {
          public A()
          {
            System.Console.WriteLine("This is a {0},", this.GetType());
          }
        }
        class B : A
        {      
        }
        // . . .
        B b = new B(); // Output: "This is a Demo.B"
    }
