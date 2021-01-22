    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    
    namespace Examples.System.Net
    {
        public class WebRequestPostExample
        {
            public static void Main ()
            {
                // Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create ("https://go.urbanairship.com/api/push/");
                // Set the Method property of the request to POST.
                request.Method = "POST";
                // Create POST data and convert it to a byte array. 
