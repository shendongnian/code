    public class Program
    {
        class SomeGenericClass<T>
        {
            static SomeGenericClass()
            {
                Console.WriteLine(typeof(T));
            }
        }
    
        class Baz { }
    
        static void Main(string[] args)
        {
            SomeGenericClass<int> foo = new SomeGenericClass<int>();
            SomeGenericClass<string> bar = new SomeGenericClass<string>();
            SomeGenericClass<Baz> baz = new SomeGenericClass<Baz>();
        }
    }
