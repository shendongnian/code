    using System;
    class Test
    {
       static void F(params object[] a) {
          Console.WriteLine("F(object[])");
       }
       static void F() {
          Console.WriteLine("F()");
       }
       static void F(object a0, object a1) {
          Console.WriteLine("F(object,object)");
       }
       static void Main() {
          F();
          F(1);
          F(1, 2);
          F(1, 2, 3);
          F(1, 2, 3, 4);
       }
    }
