    class A {
        public int field;
    }
    class B : A {
        public int field; // warning. `B.field` hides `A.field`. 
    }
