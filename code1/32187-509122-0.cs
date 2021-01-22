    void Main() {
        var foo = new Foo();
        foo.Bar = "bar";
        foo.Print = () => Console.WriteLine(foo.Bar);
        foo.Print();
    }
    class Foo : IFoo {
        public String Bar { get; set; }    
        public Action Print {get;set;}
    }
