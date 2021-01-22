    interface I1 { void M(); }
    interface I2 { void M(); }
    
    class C : I1, I2
    {
        void I1.M() { ... }
        void I2.M() { ... }
    }
    C c = new C();
    c.M();  // Error, otherwise: which one?
    (c as I1).M(); // no problem
