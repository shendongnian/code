    public class MyClass1 { ~MyClass1() { Console.WriteLine("Cleaned up MyClass1"); } }
    public class MyClass2 { ~MyClass2() { Console.WriteLine("Cleaned up MyClass2"); } }
    
    public class Program
    {
        static IEnumerable<MyClass1> lotsOfObjects()
        {
            while (true)
                yield return new MyClass1();
        }
    
        static void Main()
        {
            var query = lotsOfObjects().Select(x => foo(x));
            foreach (MyClass2 x in query)
                query.ToString();
        }
    
        static MyClass2 foo(MyClass1 x)
        {
            return new MyClass2();
        }
    }
