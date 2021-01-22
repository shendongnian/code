        interface I1 { void M(); }
    interface I2 { void M(); }
    
    class C : I1, I2
    {
        public void M() { ... }
    }
    
    C c = new C();
    c.M();  // Ok, no ambiguity. Because both Interfaces gets implemented with one    method definition.
