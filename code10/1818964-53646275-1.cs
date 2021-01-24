    public class Test<T>
    {
        private readonly T _myFoo;
        public Test(T foo)
        {
            _myFoo = foo;
        }
    }
    public class ParentTest<T, TChild, TChildType> : Test<T> where TChild : Test<TChildType>
    {
        TChild Child { get; set; }
    }
    public class Impl
    {
        public void FooTest()
        {
            var parent = new ParentTest<string, Test<int>, int>("tester");
            var child = new Test<int>(1234);
            parent.Child = child;
         }
    }
