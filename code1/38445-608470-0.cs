    using System;
    using System.Web;
    
    class Test
    {
        static void Main()
        {
            string url = "DOMAIN%5CUSERNAME";
            string decoded = HttpUtility.UrlDecode(url);
            
            Console.WriteLine(decoded);
        }
    }
