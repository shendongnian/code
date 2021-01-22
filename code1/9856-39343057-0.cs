    public class Foo
    {
        public bool GetSomething => false;
    }
    public class Bar : Foo
    {
        public new bool GetSomething => true;
    }
    public static void Main(string[] args)
    {
        Foo foo = new Bar();
        Console.WriteLine(foo.GetSomething);
        
        Bar bar = new Bar();
        Console.WriteLine(bar.GetSomething);
    }
