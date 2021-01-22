    class Base<T> where T : Base<T> {
        protected Base() {
            Console.WriteLine(typeof(T).Name);
        }
    }
    class Derived : Base<Derived> {
        public Derived() { 
        }
    }
    class Program {
        public static void Main(params string[] args) {
            Derived d = new Derived();
        }
    }
