    public class A { } 
    public class B { } 
     
    static void Main(string[] args) 
    { 
       B b = new B(); 
       object obj = (object)b;
       // re-using the obj reference
       obj = new A();
       A a = (A)obj; // cast is now valid
