    public class Test<Foo,ChildFoo>
    {
        private readonly Foo _myFoo;
    
        public Test<ChildFoo> Child { get; set; }
    
        public Test(Foo foo)
        {
            _myFoo = foo;
        }
    }
    
    public class Impl
    {
        public void FooTest()
        {
            var parent = new Test<string,int>("tester");
            var child = new Test<int>(1234);
    
            parent.Child = child;
        }
    }
