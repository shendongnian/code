    public class BaseFoo
    {
        virtual public void DoSomething()
        {
            Console.WriteLine("Foo");
        }
    }
    
    public class DerivedFoo : BaseFoo
    {
        public new void DoSomething()
        {
            Console.WriteLine("Bar");
        }
    }
    
    public class DerivedBar : BaseFoo
    {
        public override void DoSomething()
        {
            Console.WriteLine("FooBar");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            BaseFoo derivedBarAsBaseFoo = new DerivedBar();
            BaseFoo derivedFooAsBaseFoo = new DerivedFoo();
    
            DerivedFoo derivedFoo = new DerivedFoo();
    
            derivedFooAsBaseFoo.DoSomething(); //Prints "Foo" when you might expect "Bar"
            derivedBarAsBaseFoo.DoSomething(); //Prints "FooBar"
    
            derivedFoo.DoSomething(); //Prints "Bar"
        }
    }
