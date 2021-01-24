    public class Test<T1, T2> : ITest where T2 : ITest
    {
        private readonly T1 _myFoo;
        public T2 Child { get; set; }
        public void A()
        {
        }
        public void B()
        {
            Child.A();
        }
        public Test(T1 foo)
        {
            _myFoo = foo;
        }
    }
    public interface ITest
    {
        void A();
        void B();
    }
    public class Impl
    {
        public void FooTest()
        {
            var parent = new Test<string, Test<int, ITest>>("tester");
            var child = new Test<int, ITest>(1234);
            parent.Child = child;
        }
    }
