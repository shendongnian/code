    class Foo
    {
        public void SomeFunction(int i) { }
    }
    static void Main()
    {
        int count = 0;
        List<Foo> list = new List<Foo> {new Foo()};
        list.ForEach(i => i.SomeFunction(count++));
        Console.WriteLine(count); // 1
    }
