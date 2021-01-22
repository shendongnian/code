    class VeryBase {
        public VeryBase(string name) {
            Console.WriteLine(name);
        }
    }
    class Base<T> : VeryBase where T : Base<T> {
        protected Base()
            : base(typeof(T).Name) {
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
