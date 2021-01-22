    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(IsSameUrl("http://stackoverflow.com/", "http://stackoverflow.com").ToString());
                Console.WriteLine(IsSameUrl("http://stackoverflow.com/", "http://codinghorror.com").ToString());
                Console.ReadKey();
            }
    
            static bool IsSameUrl(string url1, string url2)
            {
                Uri u1 = new Uri(url1);
                Uri u2 = new Uri(url2);
                return u1.Equals(u2);
            }
        }
    }
