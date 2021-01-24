    public class Test<T1, T2>
    {
        private readonly T1 _myFoo;
        public T2 Child { get; set; }
        public Test(T1 foo)
        {
            _myFoo = foo;
        }
    }
    public class Impl
    {
        public void FooTest()
        {
            var parent = new Test<string, Test<int, object>>("tester");
            var child = new Test<int, object>(1234);
            parent.Child = child;
        }
    }
