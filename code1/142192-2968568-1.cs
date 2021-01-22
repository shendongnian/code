    using System;
    
    using System.Threading;
    
    
    public class Simple {
    
        static object A = new object();
    
        static object B = new object();
    
    
        static void MethodA()
        {
            Console.WriteLine("Inside methodA");
            lock (A)
            {
                Console.WriteLine("MethodA: Inside LockA and Trying to enter LockB");
                Thread.Sleep(5000);           
                lock (B)
                {
                    Console.WriteLine("MethodA: inside LockA and inside LockB");
                    Thread.Sleep(5000);
                }
                Console.WriteLine("MethodA: inside LockA and outside LockB");
            }
            Console.WriteLine("MethodA: outside LockA and outside LockB");
        }
    
        static void MethodB()
        {
            Console.WriteLine("Inside methodB");
            lock (B)
            {
                Console.WriteLine("methodB: Inside LockB");
                Thread.Sleep(5000);
                lock (A)
                {
                    Console.WriteLine("methodB: inside LockB and inside LockA");
                    Thread.Sleep(5000);
                }
                Console.WriteLine("methodB: inside LockB and outside LockA");
            }
            Console.WriteLine("methodB: outside LockB and outside LockA");
        }
    
        public static void Main(String[] args)
        {
    
            Thread Thread1 = new Thread(MethodA);
            Thread Thread2 = new Thread(MethodB);
            Thread1.Start();
            Thread2.Start();
            Console.WriteLine("enter.....");
            Console.ReadLine();
    
        }
    }
