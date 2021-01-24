    public class Parent { }
    public class Derived : Parent { }
    public class NotDerived { }
    
    Parent p1 = (Derived)null; // This will compile
    Parent p2 = (NotDerived)null; // This won't compile
