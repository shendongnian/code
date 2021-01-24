    public abstract class ClassA
    {
        public virtual void SayHelloFromA()
        {
            Console.WriteLine("Hello From A");
        }
    }
    public class ClassB : ClassA
    {
        public void SayHelloFromB()
        {
            Console.WriteLine("Hello From B");
        }
    }
    public class ClassC
    {
        public void SayHello()
        {
            var b = new ClassB();
            b.SayHelloFromA();
            b.SayHelloFromB();
        }
    }
