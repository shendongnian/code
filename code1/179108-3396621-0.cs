     class MyClass {
        
           static void Main() {
              object o = null;
              object p = null;
              object q = new Object();
              
              //Here o and p not referring to any location.so result true
              Console.WriteLine(Object.ReferenceEquals(o, p));
              p = q; // here p's memory location is mapping to q.So both referring to same memory    location. so result is true.
              Console.WriteLine(Object.ReferenceEquals(p, q));
                //Here the p and o are in different memory location so the result is false
              Console.WriteLine(Object.ReferenceEquals(o, p));
           }
        }
