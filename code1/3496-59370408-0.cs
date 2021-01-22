cs
using System;
using System.Linq;
namespace TestConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const int x = 5;
            var dispatch = new DoubleDispatch();
            Console.WriteLine(dispatch.Foo<int>(x));
            Console.WriteLine(dispatch.Foo<string>(x.ToString()));
            Console.ReadLine();
        }
    }
    public class DoubleDispatch
    {
        public T Foo<T>(T arg)
        {
            var method = GetType()
                .GetMethods()
                .Single(m =>
                    m.Name == "Foo" &&
                    m.GetParameters().Length == 1 &&
                    arg.GetType().IsAssignableFrom(m.GetParameters()[0].ParameterType) &&
                    m.ReturnType == typeof(T));
            return (T) method.Invoke(this, new object[] {arg});
        }
        public int Foo(int arg)
        {
            return arg;
        }
        public string Foo(string arg)
        {
            return arg;
        }
    }
}
