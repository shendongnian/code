    interface IBase
    {
        void F();
    }
    interface IDerived: IBase
    {
        void G();
    }
    class C: IDerived
    {
        void IBase.F() {…}
        void IDerived.G() {…}
    }
    class D: C, IDerived
    {
        public void F() {…}
        public void G() {…}
    }
