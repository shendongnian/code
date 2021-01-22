    class Program {
       public delegate double Integrand(double x);   
       // Define implementations to above delegate 
       // with similar input and output types
       static double MyFunc1(double x) { /* ... */ }
       static double MyFunc2(double x) { /* ... */ }
       // ... etc ...
       public static double Gauss3(Integrand f, ...) { 
          // Now just call the function naturally, no f.eval() stuff.
          double a = f(x); 
          // ...
       }
       // Let's use it
       static void Main() {
         // Just pass the function in naturally (well, its reference).
         double res = Gauss3(MyFunc1, a, b, n);
         double res = Gauss3(MyFunc2, a, b, n);    
       }
    }
