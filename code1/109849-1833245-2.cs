    using System;
    
    namespace ConsoleApplication9
    {
        public class Base
        {
            public virtual void Test(String s)
            {
                Console.Out.WriteLine("Base.Test(String=" + s + ")");
            }
        }
    
        public class Descendant : Base
        {
            public override void Test(String s)
            {
                Console.Out.WriteLine("Descendant.Test(String=" + s + ")");
            }
    
            public void Test(Object s)
            {
                Console.Out.WriteLine("Descendant.Test(Object=" + s + ")");
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Descendant d = new Descendant();
                d.Test("Test");
                Console.In.ReadLine();
            }
        }
    }
