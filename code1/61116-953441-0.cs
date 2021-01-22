    public abstract class Singleton<T>
        where T: Singleton<T>
    {
        public static T Instance
        {
            get { return Nested.instance; }
        }
        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() { }
            internal static readonly T instance = new T();
        }
    }
    public sealed class MyType : Singleton<MyType>
    {
    }
    class Program
    {
        static void Main()
        {
            // two usage pattterns are possible:
            Console.WriteLine(
                ReferenceEquals(
                    Singleton<MyType>.Instance, 
                    MyType.Instance
                )
            );
            Console.ReadLine();
        }
    }
