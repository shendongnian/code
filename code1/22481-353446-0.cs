    using System;
    
    namespace ConsoleApplicationTest {
        class Program {
            static void Main(string[] args) {
    
                int loopCount = 1000000000;
    
                System.Diagnostics.Stopwatch timer1 = new System.Diagnostics.Stopwatch();
                timer1.Start();
                Foo foo = new Foo();
                for (int i = 0; i < loopCount; i++) {
                    foo.SomeMethod();
                }
                timer1.Stop();
                Console.WriteLine(timer1.ElapsedMilliseconds);
    
                System.Diagnostics.Stopwatch timer2 = new System.Diagnostics.Stopwatch();
                timer2.Start();
                Bar bar = new Bar();
                for (int i = 0; i < loopCount; i++) {
                    foo.SomeMethod();
                }
                timer2.Stop();
                Console.WriteLine(timer2.ElapsedMilliseconds);
    
                Console.ReadLine();
            }
        }
    
        public class Bar {
            public void SomeMethod() {
                Logger.Log(this.GetType(), "SomeMethod started...");
            }
        }
    
        public class Foo {
            private static readonly Type myType = typeof(Foo); 
            public void SomeMethod() { 
                Logger.Log(myType, "SomeMethod started..."); 
            }
        }
    
        public class Logger {
            public static void Log(Type type, string text) {
            }
        }
    }
