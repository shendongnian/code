    using System;
    public abstract class Parent
    {
        public abstract void DoSomething();
    }
    public class A : Parent
    {
        public override void DoSomething()
        {
            Console.WriteLine("A.DoSomething()");
        }
    }
    public class B : Parent
    {
        public override void DoSomething()
        {
            Console.WriteLine("B.DoSomething()");
        }
    }
    public class Test
    {
        static void Main()
        {
            Parent a = new A();
            Parent b = new B();
            a.DoSomething();
            b.DoSomething();
        }
    }
