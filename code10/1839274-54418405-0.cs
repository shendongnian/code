    abstract class YourClass
    {
        public int a;
        public abstract void A();
    }
    
    class Example : YourClass
    {
        public override void A()
        {
            Console.WriteLine("Example.A");
            base.a++;
        }
    }
