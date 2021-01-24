    public class BaseClass
    {
        private readonly IFunctionality1 functionality1;
    
        public virtual void Method2() { Console.WriteLine("base2"); }
        public virtual void Method1() { this.functionality1.Method1(); }
    
        public BaseClass(IFunctionality1 functionality1)
        {
            this.functionality1 = functionality1;
        }
    }
    public class Derived1 : BaseClass
    {
        public Derived1(IFunctionality1 functionality1) : base (functionality1)
        {
    
        }
       
    }
