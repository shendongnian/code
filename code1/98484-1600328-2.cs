    public class MyBase {
        public MyBase(Action a) { }
    }
    public class MySub : MyBase {
        private string foo;
        // with "this.", says invalid use of "this"
        // without "this.", says instance required
        public MySub() : base(delegate { this.foo = "abc"; }) { }
    }
