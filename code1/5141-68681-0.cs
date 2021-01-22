    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyStr m = new MyStr();
                m.Foo();
                MyStr.MyStrInner mi = new MyStr.MyStrInner();
                mi.Bar();
                Console.ReadLine();
            }
        }
        public class Myclass
        {
            public int a;
        }
        struct MyStr
        {
            Myclass mc;
            public void Foo()
            {
                mc = new Myclass();
                mc.a = 1;
            }
            public class MyStrInner
            {
                string x = "abc";
                public string Bar()
                {
                    return x;
                }
            }
        }
    }
