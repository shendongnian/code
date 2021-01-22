    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace AppDomainTestingUnhandledException
    {
        class Program
        {
            static void Main(string[] args)
            {
                AppDomain.CurrentDomain.UnhandledException +=
                    (sender, eventArgs) => Console.WriteLine("Something went wrong! " + args);
                var ad = AppDomain.CreateDomain("Test");
                var service =
                    (RunInAnotherDomain)
                    ad.CreateInstanceAndUnwrap(
                        typeof(RunInAnotherDomain).Assembly.FullName, typeof(RunInAnotherDomain).FullName);
                try
                {
                    service.Start();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Crash: " + e.Message);
                }
                finally
                {
                    AppDomain.Unload(ad);
                }
            }
        }
        class RunInAnotherDomain : MarshalByRefObject
        {
            public void Start()
            {
                Task.Run(
                    () =>
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("Uh oh!");
                            throw new Exception("Oh no!");
                        });
                while (true)
                {
                    Console.WriteLine("Still running!");
                    Thread.Sleep(300);
                }
            }
        }
    }
