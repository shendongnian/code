    public class Manipulate
        {        
            public static int Main(string[] args) {
                Bar bar = new Bar();
                bar.BarFoo();
                Console.ReadKey();
                return 0;
            }
            
        }
        public class Foo {
            public static bool SomeCheck() {
                return true;
            }
        }
        public class Bar {
            // what happens when we access Foo to call SomeCheck?
            public void BarFoo() {
                if (Foo.SomeCheck()) {
                    Console.WriteLine("Hello am true");
                }
            }
        }
