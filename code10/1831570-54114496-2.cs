    public class A2 : IA
    {
    }
    B b = new B();  // fine
    IB ib = b;      // fine
    ib.PropertyA = new A2();  // blows up at runtime since B can only hold A objects in PropertyA
