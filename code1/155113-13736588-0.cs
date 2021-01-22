    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleCSharp
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyClass mclass = new MyClass();
    
                IA IAClass = (IA) mclass;
                IB IBClass = (IB)mclass;
    
                string test1 = IAClass.Foo();
                string test33 = IBClass.Foo();
    
    
                int inttest = IAClass.Foo2();
                string test2 = IBClass.Foo2();
                
    
                Console.ReadKey();
            }
        }
    public class MyClass : IA, IB
    {
        static MyClass()
        {
            Console.WriteLine("Public class having static constructor instantiated.");
        }
        string IA.Foo()
        {
            Console.WriteLine("IA interface Foo method implemented.");
            return ""; 
        }
        string IB.Foo()
        {
            Console.WriteLine("IB interface Foo method  having different implementation. ");
            return "";
        }
        int IA.Foo2()
        {
            Console.WriteLine("IA-Foo2 which retruns an integer.");
            return 0;
        }
       
        string IB.Foo2()
        {
            Console.WriteLine("IA-Foo2 which retruns an string.");
            return "";
        }
    }
    public interface IA
    {
        string Foo(); //same return type
        int Foo2(); //different return tupe
    }
    public interface IB
    {
        string Foo();
        string Foo2();
    }
}
