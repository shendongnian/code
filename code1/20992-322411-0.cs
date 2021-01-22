    using System;
    using System.Reflection;
    public class Foo
    {
        public int Bar { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            MethodInfo method = typeof(Foo).GetProperty("Bar").GetSetMethod();
            Action<Foo, int> setter = (Action<Foo, int>)
                Delegate.CreateDelegate(typeof(Action<Foo, int>), method);
    
            Foo foo = new Foo();
            setter(foo, 12);
            Console.WriteLine(foo.Bar);
        }
    }
