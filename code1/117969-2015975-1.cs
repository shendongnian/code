    class Base {
        public int abc = 3;
    }
    class Derived : Base {
        public int abc = 2;
    } 
    static void Main(string[] args)
    {
        Derived foo = new Derived();
        Console.WriteLine(foo.abc);
        Base bar = new Derived();
        Console.WriteLine(bar.abc);
    }
