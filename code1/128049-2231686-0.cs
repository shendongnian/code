    public static class C1Extensions
    {
        public static void Func1(this C1 o)
        {
            // ...
        }
    }
    public class C1
    {
        public void Foo()
        {
           this.Func1();
        }
    }
