    public class MyClass
    {
        ~MyClass() { Console.WriteLine("Cleaned up"); }
    }
    public class Program
    {
        static IEnumerable<MyClass> lotsOfObjects()
        {
            while (true)
                yield return new MyClass();
        }
        static void Main()
        {
            var query = lotsOfObjects().Select(z => foo(z));
            foreach (MyClass x in query)
                query.ToString();
        }
        private MyClass foo(MyClass z)
        {
            return z;
        }
    }
