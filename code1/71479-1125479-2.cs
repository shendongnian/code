    public abstract class A
    {
        public virtual void Foo()
        {
            Console.WriteLine("A's Foo");
        }
        public abstract void Goo();
    }
    public abstract class B : A
    {
        public abstract override void Foo();
        public override void Goo()
        {
            Console.WriteLine("Only wanted to implement goo");
        }
    }
    public class C : B
    {
        public override void Foo()
        {
            Console.WriteLine("Only wanted to implement foo");
        }
    }
