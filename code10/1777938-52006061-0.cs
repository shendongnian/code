    using System;
    using System.Diagnostics;
    namespace Scratch
    {
        class Program
        {
            static void Main(string[] args)
            {
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                throw new Exception("Uh oh!");
            }
            private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
            {
                using (var eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry($"Unhandled exception {(e.ExceptionObject as Exception).Message}");
                }
            }
        }
    }
