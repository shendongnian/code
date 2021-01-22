    using System;
    
    namespace interfaceClass
    {
        public interface ITest
        {
            void Execute();
        }
    
        public class Base : ITest
        {
            void ITest.Execute()
            {
                Console.Out.WriteLine("Base.ITest.Execute");
            }
        }
    
        public class Descendant : Base, ITest
        {
            void ITest.Execute()
            {
                Console.Out.WriteLine("Descendant.ITest.Execute");
            }
    
            public void Test()
            {
                // There's no way to call "base.Execute()" here
                ((ITest)this).Execute();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Descendant d = new Descendant();
                d.Test();
            }
        }
    }
