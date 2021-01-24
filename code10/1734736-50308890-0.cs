    public static Main(string[] args)
    {
        A test = new B();
        Console.WriteLine(test.S);    // Prints "B"
    }
    public class A
    {
        protected string s;
        public virtual string S { get => "A"; set => s = value; }
    }
    public class B : A
    {
        public override string S { get => "B"; set => s = value; }
    }
