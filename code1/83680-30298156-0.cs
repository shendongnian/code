    public class Base {
        public virtual string X() {
            return "Base";
        }
    }
    public class Derived1 : Base
    {
        public new string X()
        {
            return "Derived 1";
        }
    }
 
    public class Derived2 : Base 
    {
        public override string X() {
            return "Derived 2";
        }
    }
    Derived1 a = new Derived1();
    Base b = new Derived1();
    Base c = new Derived2();
    a.X(); // returns Derived 1
    b.X(); // returns Base
    c.X(); // returns Derived 2
