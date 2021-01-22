    class Program {
        void Foo<T>() { }
        static void Main(string[] args) {
            dynamic p = new Program();
            p.Foo<int>();
        }
    }
