    class Program
    {
        class A
        {
            public A(D d) { d.Invoke("I'm A!"); }
            public delegate string D(string s);
        }
        class B
        {
            public delegate string D(string s);
        }
        static void Main(string[] args)
        {
            //1. Func to delegates 
            string F(dynamic s) { Console.WriteLine(s); return s; }
            Func<string, string> f = F;
            //new A(f);//Error CS1503  Argument 1: cannot convert from 'System.Func<string, string>' to 'ConsoleApp3.Program.A.D'  
            new A(new A.D(f));//I'm A!
            new A(x=>f(x));//I'm A!
            Func<string, string> f2 = s => { Console.WriteLine(s); return s; };
            //new A(f2);//Same as A(f)
            new A(new A.D(f2));//I'm A!
            new A(x => f2(x));//I'm A!
            //You can even convert between delegate types
            new A(new A.D(new B.D(f)));//I'm A!
            //2. delegate to F
            A.D d = s => { Console.WriteLine(s); return s; };
            Func<string, string> f3 = d.Invoke;
            f3("I'm f3!");//I'm f3!
            Func<string, string> f4 = new Func<string, string>(d);
            f4("I'm f4!");//I'm f4!
            Console.ReadLine();
        }
    }
