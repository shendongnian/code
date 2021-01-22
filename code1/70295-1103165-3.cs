    interface ISomeMethodStrategy {
        string SomeMethod(string a, string b);
    }
    class Aa : A {
        private ISomeMethodStrategy strategy;
        private string a, b, c;
        public Aa(ISomeMethodStrategy strategy){
            this.strategy = strategy;
        }
        public override void SomeMethod() {
            a = strategy.SomeMethod(b, c);
        }
    }
