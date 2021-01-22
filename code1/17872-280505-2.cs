    class A
    {
        public virtual A SomeMethod() { ... }
    }
    class B : A
    {
        public override A SomeMethod() { ... }
        //Error	1	Type 'B' already defines a member called 'SomeMethod' with the same parameter types
        public new B SomeMethod() { ... }
    }
