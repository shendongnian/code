    public class ClassA
    {
        public virtual void method()
        {
            Console.WriteLine("1");
        }
    }
    public class ClassB : ClassA
    {
        public override void method()
        {
            Console.WriteLine("2");
        }
    }
