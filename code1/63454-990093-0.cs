    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net;
    
    /*
     * By: Bian Jiang
     * Blog: http://wifihack.net
     * 
     */
    
    public class SimpleLinsstener
    {
    
        public static void ShowRequestData(HttpListenerRequest request)
        {
            if (!request.HasEntityBody)
            {
                Console.WriteLine("No client data was sent with the request.");
                return;
            }
            System.IO.Stream body = request.InputStream;
            System.Text.Encoding encoding = request.ContentEncoding;
            System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
            if (request.ContentType != null)
            {
                Console.WriteLine("Client data content type {0}", request.ContentType);
            }
            Console.WriteLine("Client data content length {0}", request.ContentLength64);
    
            Console.WriteLine("Start of client data:");
            // Convert the data to a string and display it on the console.
            string s = reader.ReadToEnd();
            Console.WriteLine(s);
            Console.WriteLine("End of client data:");
            body.Close();
            reader.Close();
            // If you are finished with the request, it should be closed also.
        }
    
        
        // This example requires the System and System.Net namespaces.
        public static void SimpleListenerExample(string prefixes)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
            // URI prefixes are required,
            // for example "http://contoso.com:8080/index/".
            if (prefixes == null)
                throw new ArgumentException("prefixes");
    
            // Create a listener.
            HttpListener listener = new HttpListener();
            // Add the prefixes.
            //foreach (string s in prefixes)
            //{
            listener.Prefixes.Add(prefixes);
            //}
            listener.Start();
            Console.WriteLine("Listening...");
            // Note: The GetContext method blocks while waiting for a request. 
            HttpListenerContext context = listener.GetContext();
    
            HttpListenerRequest request = context.Request;
            ShowRequestData(request);
    
            
            // Obtain a response object.
            HttpListenerResponse response = context.Response;
            // Construct a response.
            string responseString = "ok";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
                
            listener.Stop();
        }
    
    
        static void Main()
        {
            // Write to console
            Console.WriteLine("Welcome to the C# Station Tutorial!");
            string[] strUserNames = new String[1] {"http://*:8080/Receive/" };
            SimpleListenerExample("http://*:8080/Receive/");
        }
    
    }
