    namespace ConsoleApplication2
    {
        public class A { }
        public class B : A { }
    
        class Program
        {
            static A a = new B();
    
            static void MyThread()
            {
                B b = a as B;
                lock (b)
                {
                    Console.WriteLine("b lock acquired");
                    Console.WriteLine("releasing b lock");
                }
    
            }
    
            
            static void Main(string[] args)
            {
                System.Threading.Thread t = new System.Threading.Thread(MyThread);
                
                lock(a)
                {
                    Console.WriteLine("a lock acquired");               
                    t.Start();
                    System.Threading.Thread.Sleep(10000);
                    Console.WriteLine("Releasing a lock");
                }
            }
        }
    }
