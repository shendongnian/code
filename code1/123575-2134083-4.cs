    public class R1 { }
    public class R2 { }
    public interface I<T> { }
    public class C1<T> : I<T> { }
    public class C2 : C1<R1>, I<R2> { }
    class Program
    {
        public static I<T> M<T>(I<T> i) { return i; }
        static void Main(string[] args)
        {
            var c2 = new C2();
            var v = M(c2); // Compiler error - no definition for M
        }
    }
