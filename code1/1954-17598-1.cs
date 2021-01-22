    public interface IInterface {
        public void Method();
    }
    public class A : IInterface {
        public void IInterface.Method() {
            // Do something
        }
    }
    public class Program {
        public static void Main() {
            A o = new A();
            o.Method(); // Will not compile
            ((IInterface)o).Method(); // Will compile
        }
    }
