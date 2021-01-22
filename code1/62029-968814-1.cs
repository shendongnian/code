    class Program {
        static void Main() {
            int i = 123;
            typeof(Program).GetMethod("Foo",
                    BindingFlags.Static | BindingFlags.NonPublic)
                .MakeGenericMethod(i.GetType())
                .Invoke(null, new object[] { i });
        }
        static void Foo<T>(T value) {
            ObjectComparer<T> comparer = new ObjectComparer<T>();
            comparer.Bar(value);
        }
    }
    class ObjectComparer<T> {
        public void Bar(T value) {
            Console.WriteLine(typeof(T).Name + " = " + value);
        }
    }
