    public class B
    { 
        A obj1 = new A(); 
        public void Foo()
        {
            A obj1 = new A(); 
            obj1.Name = "ABCDEFGH";
            C c = new C(obj1);
        }
    }
    public class C
    { 
        A obj2;
        // Constructor is called when created
        public C(A a) => obj2 = a; // obj2 will now have the same reference 
    }
