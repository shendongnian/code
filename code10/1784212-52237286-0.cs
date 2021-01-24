    class Program 
    {
        static void Main(string[] args) 
        {
            A a = new A();  // ERROR: cannot instantiate interface
            B b = new B();  // OK
            A ab = new B(); // ERROR: class B doesn't implement interface A
            B ba = new A(); // ERROR: cannot instantiate interface
            C c = new C();  // ERROR: cannot instantiate abstract class
            D d = new D();  // OK
            E e = new E();  // OK
            F af = new A(); // ERROR: cannot instantiate interface
            A fa = new F(); // OK:    class F does implement interface A
            G g = new G();  // OK
        }
    }
