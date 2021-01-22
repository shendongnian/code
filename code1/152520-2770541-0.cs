    class Foo : IBar {
        readonly dynamic duck;
        public Foo(dynamic duck) { this.duck = duck; }
        void IBar.SomeMethod(int arg) {
            duck.SomeMethod(arg);
        }
        string IBar.SomeOtherMethod() {
            return duck.SomeOtherMethod();
        }
    }
    interface IBar {
        void SomeMethod(int arg);
        string SomeOtherMethod();
    }
