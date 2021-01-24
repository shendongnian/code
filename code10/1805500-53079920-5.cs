    class BaseClass
    {    
        public virtual void DoSomething()
        {
           Console.WriteLine("Base implementation for types that don't override DoSomething()");
        }
    }
    class ChildClass1 : BaseClass{
        public override void DoSomething()
        {
            Console.WriteLine("Impl. for type ChildClass1");
        }
    }
    class ChildClass2 : BaseClass{
        public override void DoSomething()
        {
            Console.WriteLine("Impl. for type ChildClass2");
        }
    }
