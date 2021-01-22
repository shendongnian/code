    using System;
    namespace OddThrow
    {
        class Program
        {
            static void Main()
            {
                AppDomain.CurrentDomain.UnhandledException +=
                    delegate(object sender, UnhandledExceptionEventArgs e)
                {
                    Console.Out.WriteLine("In AppDomain.UnhandledException");
                };
                try
                {
                    throw new Exception("Exception!");
                }
                catch
                {
                    Console.Error.WriteLine("In catch");
                    throw;
                }
                finally
                {
                    Console.Error.WriteLine("In finally");
                }
            }
        }
    }
