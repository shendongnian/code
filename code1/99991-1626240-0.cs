    using System;
    using System.Linq;
    using System.Reflection;
    public delegate void TestMethod();
    class FooAttribute : Attribute { }
    static class Program
    {
        static void Main() {
            // find by attribute
            MethodInfo method =
                (from m in typeof(Program).GetMethods()
                 where Attribute.IsDefined(m, typeof(FooAttribute))
                 select m).First();
    
            TestMethod del = (TestMethod)Delegate.CreateDelegate(
                typeof(TestMethod), method);
            TestMetaData tmd = new TestMetaData(del, method.Name);
            tmd.Bar();
        }
        [Foo]
        public static void TestImpl() {
            Console.WriteLine("hi");
        }
    }
    
    struct TestMetaData
    {
        public TestMetaData(TestMethod method, string name)
        {
            this.method = method;
            this.testName = name;
        }
        readonly TestMethod method;
        readonly string testName;
        public void Bar() { method(); }
    }
