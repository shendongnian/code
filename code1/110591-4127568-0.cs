    static class Program
    {
        class Foo { public class Bar { public static void Func() { } } }
        class Foo2 { public static Baz Bar2 { get; set; } }
        class Baz { public void Func2() { } }
        static void Main()
        {
            Foo.Bar.Func();
            Foo2.Bar2.Func2();
        }
    }
