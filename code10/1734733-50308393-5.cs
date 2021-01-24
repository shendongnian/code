    public class A
    {
        protected virtual string s { get => "A"; }
    }
    
    public class B : A
    {
        protected override string s { get => "B"; }
    }
    
    public static void Main(string[] args)
    {
        A test = new B();
    
        Console.WriteLine(test.s); // will print B
    }
