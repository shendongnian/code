    class A { }
    class B : A, IB { }
    interface IB { }
    class C
    {
        private readonly IB _ib;
        public C(IB ib) { _ib = ib; }
        public void SomeOtherMethod(A a)
        {
            Debug.WriteLine("I am A");
        }
        public void SomeMethod()
        {
            if (_ib is A)
                SomeOtherMethod(_ib as A); //which actually requires an object of type A.
            else
                Debug.WriteLine("I am not A");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            C c = new C(b);
            c.SomeMethod();
        }
    }
