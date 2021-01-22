    static void Main() {
        Foo x = new Bar();
        x.Go();
        var y = new Bar();
        y.Go(); // boom
    }
    class Foo {
        public void Go() { Console.WriteLine("Hi"); }
    }
    class Bar : Foo {
        public new void Go() { throw new NotImplementedException(); }
    }
