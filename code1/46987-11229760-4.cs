    using System;
    static class Program {
      static void Main() {
        try {
          ThrowTest();
        } catch (Exception e) {
          Console.WriteLine("Your stack trace:");
          Console.WriteLine(e.StackTrace);
          Console.WriteLine();
          if (e.InnerException == null) {
            Console.WriteLine("No inner exception.");
          } else {
            Console.WriteLine("Stack trace of your inner exception:");
            Console.WriteLine(e.InnerException.StackTrace);
          }
        }
      }
      static void ThrowTest() {
        decimal a = 1m;
        decimal b = 0m;
        try {
          Mult(a, b);  // line 34
          Div(a, b);   // line 35
          Mult(b, a);  // line 36
          Div(b, a);   // line 37
        } catch (ArithmeticException arithExc) {
          Console.WriteLine("Handling a {0}.", arithExc.GetType().Name);
          //   uncomment EITHER
          //throw arithExc;
          //   OR
          //throw;
          //   OR
          //throw new Exception("We handled and wrapped your exception", arithExc);
        }
      }
      static void Mult(decimal x, decimal y) {
        decimal.Multiply(x, y);
      }
      static void Div(decimal x, decimal y) {
        decimal.Divide(x, y);
      }
    }
