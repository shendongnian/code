    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    
        class MainClass
        {
    
            public static void Main(string[] args)
            {
                string myURI = "https://api.bulksms.com/v1/messages?filter=submission.date%3E%3D2018-01-01T10%3A00%3A00%2B01%3A00&limit%3D10";
                string myUsername = "someuser";
                string myPassword = "somepassword";
                var request = WebRequest.Create(myURI);
            	request.Credentials = new NetworkCredential(myUsername, myPassword);
    			request.PreAuthenticate = true;
                request.Method = "GET";
                request.ContentType = "application/json";
                try
                {
                    // make the call to the API
                    var response = request.GetResponse();
    
                    // read the response and print it to the console
                    var reader = new StreamReader(response.GetResponseStream());
                    Console.WriteLine(reader.ReadToEnd());
    
                }  catch (WebException ex) {
    				// show the general message
    				Console.WriteLine("An error occurred:" + ex.Message);
    
                    // print the detail that come with the HTTP error 
                    var reader = new StreamReader(ex.Response.GetResponseStream());
                    Console.WriteLine("Error details:" + reader.ReadToEnd());
                }
    
        }
    }
