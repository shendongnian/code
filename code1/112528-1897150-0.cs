    public class Bar : Foo {
        public int Amount { get; set; }
        public Bar() : this(0) { }
        public Bar(int amount) : this(String.Empty, amount) { }
        public Bar(string name) : this(name, 0) { }
        public Bar(string name, int amount) : base(name) {
            this.Amount = amount;
        }
    }
