    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    
    namespace StackOverflowExceptionAppDomainTest
    {
        class Program
        {
            static void recrusiveAlgorithm()
            {
                recrusiveAlgorithm();
            }
            static void Main(string[] args)
            {
                if(args.Length>0&&args[0]=="--child")
                {
                    recrusiveAlgorithm();
                }
                else
                {
                    var domain = AppDomain.CreateDomain("Child domain to test StackOverflowException in.");
                    domain.ExecuteAssembly(Assembly.GetEntryAssembly().CodeBase, new[] { "--child" });
                    domain.UnhandledException += (object sender, UnhandledExceptionEventArgs e) =>
                    {
                        Console.WriteLine("Detected unhandled exception: " + e.ExceptionObject.ToString());
                    };
                    while (true)
                    {
                        Console.WriteLine("*");
                        Thread.Sleep(1000);
                    }
                }
            }
        }
    }
