    abstract class BaseClass
    {    
        public abstract void DoSomething();
    }
    
    class ChildClass1 : BaseClass{
        public override void DoSomething()
        {
            Console.WriteLine("Impl. 1");
        }
    }
    
    class ChildClass2 : BaseClass{
        
        private string _someRandomAttribute = "Impl. 2";
        public override void DoSomething()
        {
            Console.WriteLine(_someRandomAttribute);
        }
    }
