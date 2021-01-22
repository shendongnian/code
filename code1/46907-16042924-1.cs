    //In library.dll:
    public class Base { }
    public class Derived {
        [System.Runtime.CompilerServices.SpecialName]
        public static Derived op_Implicit(Base a) {
            return new Derived(a); //Write some Base -> Derived conversion code here
        }
        [System.Runtime.CompilerServices.SpecialName]
        public static Derived op_Explicit(Base a) {
            return new Derived(a); //Write some Base -> Derived conversion code here
        }
    }
    //In program.exe:
    class Program {
        static void Main(string[] args) {
            Derived z = new Base(); //Visual Studio can show squiggles here, but it compiles just fine.
        }
    }
