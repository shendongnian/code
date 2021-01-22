    interface ISomeMethodStrategy {
        string SomeMethod(string a, string b);
    }
    class DefaultStrategy : ISomeMethodStrategy {
        public string SomeMethod(string a, string b) { return a + b; }
        public static ISomeMethodStrategy Instance = new DefaultStrategy();
    }
    class DifferentStrategy : ISomeMethodStrategy {
        public string SomeMethod(string a, string b) { return b + a; }
        public static ISomeMethodStrategy Instance = new DifferentStrategy();
    }
    class A {
        private ISomeMethodStrategy strategy;
        private string a, b, c;
        public A() : this(DefaultStrategy.Instance) {}
        protected A(ISomeMethodStrategy strategy){
            this.strategy = strategy;
        }
        public void SomeMethod() {
            a = strategy.SomeMethod(b, c);
        }
    }
    class Aa : A {
        public Aa() : base(DifferentStrategy.Instance) {}
    }
