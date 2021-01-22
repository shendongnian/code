    public class Base
    {
        public virtual void Foo()
        {
            Console.WriteLine("Hello from Base");
        }
    }
    
    public class Derived : Base
    {
        public override void Foo()
        {
            base.Foo();
            Console.WriteLine("Text 1");
            WriteText2Func();
            Console.WriteLine("Text 3");
        }
    
        protected virtual void WriteText2Func()
        {  
            Console.WriteLine("Text 2");  
        }
    }
    
    public class Special : Derived
    {
        public override void WriteText2Func()
        {
            //WriteText2Func will write nothing when 
            //method Foo is called from class Special.
            //Also it can be modified to do something else.
        }
    }
</pre> 
