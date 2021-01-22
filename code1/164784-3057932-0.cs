    namespace trash {
        public class Class1 {
            public void CallMe() {
                string blah = null;
                blah.ToLower();
            }
        }
    
        class Program {
            static void Main(string[] args) {
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);           
                var class1 = typeof(Class1);
                var method = class1.GetMethod("CallMe");
    
                try {
                    var obj = new Class1();
                    method.Invoke(obj, null); // exception is not being caught!
                }
                catch (System.Reflection.TargetInvocationException) {
                    Console.Write("what you would expect");
                }
    
            }
    
            static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
                Console.Write("it would be horrible if this got tripped but it doesn't!");
            }
        }
    }
