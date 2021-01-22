    using System;
    
    class Test
    {
        static void Main()
        {
            Console.WriteLine(ConvertToPunycode("caf\u00e9.com"));
        }
        
        static string ConvertToPunycode(string domain)
        {
            Uri uri = new Uri("http://"+domain);
            return uri.DnsSafeHost;
        }
    }
