    class MyBaseClass<T> where T : MyBaseClass<T>, new()
    {
        public T Retrieve()
        {
            return new T();
        }
    }
    
    class Foo : MyBaseClass<Foo>
    {
    }
    
    class Program
    {
        public static void Main()
        {
            Foo f = new Foo();
            Foo f2 = f.Retrieve();
            Console.WriteLine(f2.ToString());
        }
    }
