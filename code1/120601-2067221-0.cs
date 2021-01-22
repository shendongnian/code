    class Program {
        static void Main(string[] args) {
            new Derived().Test();
        }
    }
    public class Base {
        [System.Diagnostics.Conditional("DEBUG")]
        public virtual void Test() { Console.WriteLine("base");  }
    }
    public class Derived : Base {
        public override void Test() {
            base.Test();
        }
    }
