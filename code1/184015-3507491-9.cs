    class Foo {
        public override bool Equals(object obj) { return true; }  }
    var a = new Foo();
    var b = new Foo();
    Console.WriteLine( Object.Equals(a,b) );  // outputs "True!"
