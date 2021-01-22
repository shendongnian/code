    namespace GenericBind {
        class Program {
            static void Main(string[] args) {
                Type t = Type.GetType("GenericBind.B");
                MethodInfo genericMethod = typeof(Program).GetMethod("Method");
                MethodInfo constructedMethod = genericMethod.MakeGenericMethod(t);
                Console.WriteLine((string)constructedMethod.Invoke(null, new object[] {new B() }));
                Console.ReadKey();
            }
            public static string Method<T>(T obj) {
                return obj.ToString();
            }
        }
        public class B {
            public override string ToString() {
                return "Generic method called on " + GetType().ToString();
            }
        }
    }
