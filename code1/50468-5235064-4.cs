    using System.Console;
    
    class A[T]
    {
        public static @:[From](x : A[From]) : A[T]
        {
          A()
        }
    }
    
    
    class Base{}
    class Derived{}
    
    
    def a = A.[Derived]();
    def b : A[Base] = a;
    
    WriteLine($"$a $b");
