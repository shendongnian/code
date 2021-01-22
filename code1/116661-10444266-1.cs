    using System;
            using System.Threading;
            class sycexp
                    {
                    public static void Main()
                            {
                            exp e=new exp();
                            Thread t1=new Thread(new ThreadStart(e.show));
                            Thread t2=new Thread(new ThreadStart(e.show));
                            t1.Name="First Thread";
                            t2.Name="Second Thread";
                            t1.Start();
                            t2.Start();
                            }
                     }
            class exp
                    {
                    public object lockme=new object();
                    public void show()
                            {
                            lock(lockme)
                                    {
                                    Console.WriteLine("Start "+Thread.CurrentThread.Name.ToString());
                                    Console.WriteLine("1");
                                    Console.WriteLine("2");
                                    Console.WriteLine("3");
                                    Console.WriteLine("4");
                                    Console.WriteLine("5");
                                    Console.WriteLine(Thread.CurrentThread.Name.ToString()+" Stopped");
                                    }
                            }
                     }
