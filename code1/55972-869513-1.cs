        static void Main(string[] args)
        {
            Console.WriteLine(new Foo<string>("myValue").IsValueAString);
            Console.WriteLine(new Foo<int>(1).IsValueAString);
            Console.ReadLine();
        }
        public class Foo<T>
        {
            public bool IsValueAString = false;
            public Foo(T value) {
                if (value is string)
                {
                    IsValueAString = true;
                }
            }
        }
