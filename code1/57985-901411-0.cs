    using System;
    using System.Net;
    using System.IO;
    public class Test
    {
        public static String GetRequest (string theService, string[] params)
        {
            WebClient client = new WebClient ();
            // Add a user agent header in case the 
            // requested URI contains a query.
            client.Headers.Add ("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            Stream data = client.OpenRead (
                theService + "?" +String.Join("?", params));
            StreamReader reader = new StreamReader (data);
            return = reader.ReadToEnd ();
        }
    }
