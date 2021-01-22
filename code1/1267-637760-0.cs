    namespace constructorChain {
        using System;
        public class Class1 {
            public string x;
            public string y;
            public Class1() {
                x = "class1";
                y = "";
            }
            public Class1(string y)
                : this() {
                this.y = y;
            }
        }
        public class Class2 : Class1 {
            public Class2(int y)
                : base(y.ToString()) {
            }
        }
    }
...
            constructorChain.Class1 c1 = new constructorChain.Class1();
            constructorChain.Class1 c12 = new constructorChain.Class1("Hello, Constructor!");
            constructorChain.Class2 c2 = new constructorChain.Class2(10);
            Console.WriteLine("{0}:{1}", c1.x, c1.y);
            Console.WriteLine("{0}:{1}", c12.x, c12.y);
            Console.WriteLine("{0}:{1}", c2.x, c2.y);
            Console.ReadLine();
