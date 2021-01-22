    using System;
    using System.Reflection;
    namespace ConsoleApplication1 {
        [AttributeUsage(AttributeTargets.Method)]
        internal class ProvidesAttribute : Attribute {
            private String[] _strings;
            public ProvidesAttribute(params String[] strings) {
                _strings = strings;
            }
            public bool Contains(String str) {
                foreach (String test in _strings) {
                    if (test.Equals(str)) {
                        return true;
                    }
                }
                return false;
            }
        }
        internal class Program {
            [Provides("hello", "goodbye")]
            public void HandleSomeStuff(String str) {
                Console.WriteLine("some stuff: {0}", str);
            }
            [Provides("this")]
            public void HandleMoreStuff(String str) {
                Console.WriteLine("more stuff: {0}", str);
            }
            public void HandleString(String str) {
                // we could loop through each Type in the assembly here instead of just looking at the
                // methods of Program; this would allow us to push our "providers" out to other classes
                MethodInfo[] methods = typeof(Program).GetMethods();
                foreach (MethodInfo method in methods) {
                    Attribute attr = Attribute.GetCustomAttribute(method, typeof(ProvidesAttribute));
                    ProvidesAttribute prov = attr as ProvidesAttribute;
                    if ((prov != null) && (prov.Contains(str))) {
                        method.Invoke(this, new Object[] { str } );
                        break;  // removing this enables multiple "providers"
                    }
                }
            }
            internal static void Main(String[] args) {
                Program prog = new Program();
                foreach (String str in args) {
                    prog.HandleString(str);
                }
            }
        }
    }
