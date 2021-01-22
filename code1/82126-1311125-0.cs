    class Program
        {
            static void Main()
            {
                Buzz<Foo>(x => Foo.Bar);
            }
    
            public static void Buzz<T>(Func<T, string> getPropertyValue)
            {
                var value = getPropertyValue(default(T));
                //value=="fizz" which is what i needed
            }
        }
    
        public class Foo
        {
            public static string Bar = "fizz";
        }
