    using System;
    class Foo<T>
    {
        public T Value { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            var obj = new Foo<int> { Value = 123 };
            var prop = obj.GetType().GetProperty("Value");
            Func<Foo<int>, int> getter = (Func<Foo<int>, int>)
                Delegate.CreateDelegate(
                  typeof(Func<Foo<int>, int>), prop.GetGetMethod());
            int x = getter(obj);
            Console.WriteLine(x);
            Action<Foo<int>, int> setter = (Action<Foo<int>, int>)
                Delegate.CreateDelegate(
                  typeof(Action<Foo<int>, int>), prop.GetSetMethod());
            setter(obj, 321);
            Console.WriteLine(obj.Value);
        }
    }
