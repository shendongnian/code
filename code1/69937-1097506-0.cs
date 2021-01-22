    using System;
    using System.Net;
    
    public class TestApp {
        public static void Main( string[] args ) {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.stackoverflow.com/");
            WebResponse response = request.GetResponse();
            Console.Out.WriteLine( response.Headers.Get("Server") );
        }
    }
    // Output:
    // Microsoft-IIS/7.0
