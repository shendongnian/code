    class A
    {
        private string mystring = "A";    
        public string Method1()
        {
            return mystring;
        }
    }
    
    class B : A
    {
        // this inherits Method1() naturally
    }
    
    class C : B
    {
        // this inherits Method1() naturally
    }
    
    string newstring = "";
    A a = new A();
    B b = new B();
    C c = new C();
    newstring = a.Method1();// returns "A"
    newstring = b.Method1();// returns "A"
    newstring = c.Method1();// returns "A"
