    public class Foo {
        private readonly Bar bar;
        public Foo(Bar bar) { this.bar = bar; }
 
        public int Id { get {return bar.Id; } set {bar.Id = value; } }
        public string Name {get;set;}
    }
