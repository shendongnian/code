    public abstract class A
    {
        public abstract void Process();
    }
    public abstract class B : A
    {
    }
    public class C : B
    {
        public override void Process()
        {
            Console.WriteLine("abc");
        }
    }
