    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                dynamic a = new C();
    
                a.method();
                Console.ReadLine();
            }
        }
    
        public class A
        {
            public void method()
            {
                Console.WriteLine("METHOD FROM A");
            }
        }
    
        public class B : A { }
    
        public class C : B
        {
            public new void method()
            {
                Console.WriteLine("METHOD FROM C");
            }
        }
    }
