    public class Class1
    {
        public static void Foo(Func<object, string> f)
        {
            Console.WriteLine(f.Method.GetParameters()[0].Name);
        }
    }
