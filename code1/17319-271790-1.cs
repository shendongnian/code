    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            static void Main(string[] args)
            {
                using (var wc = new WebClient())
                {
                    wc.DownloadStringCompleted += (sender, e) => Console.WriteLine(e.Result);
                    wc.DownloadStringAsync(new Uri("http://quicktuner.net/install.html"));
                }
    
                Console.WriteLine("END OF APP ---------------------- ");
                Console.ReadKey();
            }
        }
    }
