    // Poor-man's static interface (DI).
    public static class OriginalBuiltInStaticClass {
        public static Action A = new MyNewClass().A;
        public static Func<int, string> B = new MyNewClass().B;
        public static Action C = new MyNewClass().C;
    }
    // Original vendor class which was copied and renamed.
    public static class CopySimpleRenameBuiltInStaticClass {
        public static void A() {
            Console.WriteLine("OriginalBuiltInStaticClass.A()");
        }
        public static string B(int id) {
            Console.WriteLine("OriginalBuiltInStaticClass.B()");
            return id.ToString();
        }
        public static void C() {
            Console.WriteLine("OriginalBuiltInStaticClass.C()");
        }
    }
    // Creating an interface to merge into trunk of NopCommerce (convert static repositories)
    public interface IMyNewClass {
        void A();
        string B(int id);
        void C();
    }
    // Implementation of interface.
    public class MyNewClass : IMyNewClass {
        public void A() {
            Console.WriteLine("MyNewClass.A()");
        }
        public string B(int id) {
            Console.WriteLine("MyNewClass.B()");
            return id.ToString();
        }
        public void C() {
            CopySimpleRenameBuiltInStaticClass.C();
        }
    }
