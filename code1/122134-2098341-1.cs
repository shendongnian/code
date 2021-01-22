    class Program {
        static Action Curry<T>(Action<T> action, T parameter) {
            return () => action(parameter);
        }
        static void Foo(int i) {
            Console.WriteLine("Value: {0}", i);
        }
        static void Main(string[] args) {
            Action curried = Curry(Foo, 5);
            curried();
        }
    }
