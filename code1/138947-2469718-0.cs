    class Foo
    {
        public int Bar { get; set; }
    
        public string Name { get; set; }
    }
    
    public static void Main(string[] args)
    {
        Foo f = new Foo { Bar = 1, Name = "1" };
        Console.WriteLine("{0}.{1}", f.Bar, f.Name);
    
        Action<Foo> set = (Foo foo) => { foo.Bar = 2; foo.Name = "2"; };
    
        set(f);
        Console.WriteLine("{0}.{1}", f.Bar, f.Name);
    }
