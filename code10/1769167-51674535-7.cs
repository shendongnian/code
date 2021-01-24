    using System;
    using Microsoft.Owin.Hosting;
    
    namespace OpenIddictOwinDemo
    {
        public static class Program
        {
            public static void Main(string[] args)
            {
                const string address = "http://localhost:12556/";
    
                using (WebApp.Start<Startup>(address))
                {
                    Console.WriteLine($"Server is running on {address}, press CTRL+C to stop.");
                    Console.ReadLine();
                }
            }
        }
    }
