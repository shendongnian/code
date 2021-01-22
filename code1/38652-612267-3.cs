    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Linq;
    using System.Linq.Parallel;
    
    public class Test
    {
     
        static void Main()
        {
            var urls = Enumerable.Range(0, 100).Select(i => i.ToString());
            
            int threads = 10;
            Dictionary<string, string> results = urls.AsParallel(threads)
                .Select(url => new { Url=url, Page=GetPage(url) })
                .ToDictionary(x => x.Url, x => x.Page);
        }
        
        static string GetPage(string x)
        {
            Console.WriteLine("On thread {0} getting {1}",
                              Thread.CurrentThread.ManagedThreadId, x);
            Thread.Sleep(2000);
            return x;
        }
    }
