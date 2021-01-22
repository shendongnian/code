    class A
    {  
        public int foo;  
    }
    
    class B : A {}
    
    class C : B
    {
        void bar()
        {
            //I want to access foo
            base.foo; // Now you can see it
        }
    }
