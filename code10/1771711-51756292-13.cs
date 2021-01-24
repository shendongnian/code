    public class A
    {
        public int Index { get; set; }
        public virtual void PrintLine()
        {
            Console.WriteLine($"A {Index}");
        }
    }
    public class B : A
    {
        public override void PrintLine()
        {
            Console.WriteLine($"B {Index}");
        }
    }
    public class C : B
    {
        public override void PrintLine()
        {
            Console.WriteLine($"C {Index}");
        }
    }
