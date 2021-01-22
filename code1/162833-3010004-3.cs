    class DefaultStringVisitor : IBaseVisitor<string> {
        public string Visit(Base x) { return x.BaseString; }
        public string Visit(Derived1 x) { return x.Derived1String; }
        public string Visit(Derived2 x) { return x.Derived2String; }
    }
    class Dependent {
        public Dependent(Base x) {
            string whatever = x.Accept<string>(new DefaultStringVisitor());
        }
    }
