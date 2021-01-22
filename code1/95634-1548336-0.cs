    public class Foo
    {
        private string bar;
    }
    public static class FooExtensions
    {
        public static void Test(this Foo foo)
        {
            // Compile error here: Foo.bar is inaccessible due to its protection level	
            var bar = foo.bar;
        }
    }
