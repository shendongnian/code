    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace ReferenceTypes
    {
        class DeadLockExample
        {
            static int a;
            static int b;
            static object lockedObjA = new object();
            static object lockedObjB = new object();
    
            public static void Main(string[] args)
            {
                DeadLockExample.a = 20;
                DeadLockExample.b = 30;
    
                DeadLockExample d = new DeadLockExample();
    
                Thread tA = new Thread(new ThreadStart(d.MethodA));
                Thread tB = new Thread(new ThreadStart(d.MethodB));
    
                tA.Start();
                tB.Start();
    
                Console.ReadLine();
            }
    
            private void MethodA()
            {
                lock (DeadLockExample.lockedObjA)
                {
                    Console.WriteLine(a);
                    Thread.Sleep(1200);
                    lock (DeadLockExample.lockedObjB) {
                        Console.WriteLine(b);
                    }
                }
            }
    
            private void MethodB()
            {
                lock (DeadLockExample.lockedObjB)
                {
                    Console.WriteLine(b);
                    Thread.Sleep(1000);
                    lock (DeadLockExample.lockedObjA) {
                        Console.WriteLine(a);
                    }
                }
            }
         }
    }
