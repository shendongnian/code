    class A
    {
        public virtual void SomeMethod()
        {
            Console.Write("This is A");
        }
    }
    
    class B : A
    {
        public override void SomeMethod()
        {
            Console.Write("This is B");
        }
    
        public void OtherMethod()
        {
            Console.Write("This is New method");
        }
    }
